using Agava.YandexGames;
using UnityEngine;

public class BagRewardUpgradeButton : RewardUpgradeButton
{
    [SerializeField] private PlayerBag _bag;

    private void OnEnable()
    {
        Button.onClick.AddListener(ShowReward);
        _bag.MaxLevelReached += OnMaxLevelReached;
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(ShowReward);
        _bag.MaxLevelReached -= OnMaxLevelReached;
    }

    private void ShowReward()
    {
#if UNITY_WEBGL
        VideoAd.Show(onRewardedCallback: OnUpgrade);
#endif
    }

    private void OnUpgrade()
    {
            _bag.IncreaseMaxCapacity();
    }

    private void OnMaxLevelReached()
    {
        Destroy(gameObject);
    }
}
