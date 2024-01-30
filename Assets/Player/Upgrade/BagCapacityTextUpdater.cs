using UnityEngine;

public class BagCapacityTextUpdater : UpgradeTextUpdater
{
    [SerializeField] private PlayerBag _bag;

    protected override void OnEnable()
    {
        _bag.LevelIncreased += OnLevelIncreased;
        _bag.MaxLevelReached += OnMaxLevelReached;
    }

    protected override void OnDisable()
    {
        _bag.LevelIncreased -= OnLevelIncreased;
        _bag.MaxLevelReached -= OnMaxLevelReached;
    }

    protected override void OnLevelIncreased()
    {
        LevelText.text = _bag.CurrentLevel.ToString();
        PriceText.text = UpgradeButton.GetPrice(_bag.CurrentLevel - 1).ToString();
    }
}
