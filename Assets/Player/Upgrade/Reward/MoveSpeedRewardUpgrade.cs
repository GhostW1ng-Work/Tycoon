using UnityEngine;
using Agava.YandexGames;

public class MoveSpeedRewardUpgrade : RewardUpgradeButton
{
    [SerializeField] private PlayerMover _mover;

    private void OnEnable()
    {
        Button.onClick.AddListener(ShowReward);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(ShowReward);
    }

    private void ShowReward()
    {
#if UNITY_WEBGL
        VideoAd.Show(onRewardedCallback: OnUpgrade);
#endif
    }

    private void OnUpgrade()
    {
        if (_mover.CurrentLevel >= _mover.MaxLevel)
        {
            Upgrade.MaxLevelReached?.Invoke();
            Destroy(Upgrade.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Upgrade.IncreaseCurrentLevel();
            Upgrade.LevelIncreased?.Invoke();
            _mover.IncreaseMoveSpeed();
            if (_mover.CurrentLevel >= _mover.MaxLevel)
            {
                Upgrade.MaxLevelReached?.Invoke();
                Destroy(Upgrade.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
