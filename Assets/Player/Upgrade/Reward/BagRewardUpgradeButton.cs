using Agava.YandexGames;
using UnityEngine;

public class BagRewardUpgradeButton : RewardUpgradeButton
{
    [SerializeField] private PlayerBag _bag;

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

        if (_bag.CurrentLevel >= _bag.MaxLevel)
        {
            Upgrade.MaxLevelReached?.Invoke();
            Destroy(Upgrade.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Upgrade.IncreaseCurrentLevel();
            Upgrade.LevelIncreased?.Invoke();
            _bag.IncreaseMaxCapacity();
            if (_bag.CurrentLevel >= _bag.MaxLevel)
            {
                Upgrade.MaxLevelReached?.Invoke();
                Destroy(Upgrade.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
