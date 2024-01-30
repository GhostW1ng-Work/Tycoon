using UnityEngine;
using Agava.YandexGames;

public class MoveSpeedRewardUpgrade : RewardUpgradeButton
{
    [SerializeField] private PlayerMover _mover;

    private void OnEnable()
    {
        Button.onClick.AddListener(ShowReward);
        _mover.MaxLevelReached += OnMaxLevelReached;
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(ShowReward);
        _mover.MaxLevelReached -= OnMaxLevelReached;
    }

    private void ShowReward()
    {
#if UNITY_WEBGL
        VideoAd.Show(onRewardedCallback: OnUpgrade);
#endif
    }

    private void OnUpgrade()
    {
        _mover.IncreaseMoveSpeed();
    }

    private void OnMaxLevelReached()
    {
        Destroy(gameObject);
    }
}
