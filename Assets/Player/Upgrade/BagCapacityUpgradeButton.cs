using UnityEngine;

public class BagCapacityUpgradeButton : UpgradeButton
{
    [SerializeField] private PlayerBag _bag;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnUpgrade);
        _bag.MaxLevelReached += OnMaxLevelReached;
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnUpgrade);
        _bag.MaxLevelReached -= OnMaxLevelReached;
    }

    private void OnUpgrade()
    {
        if (Wallet.TrySpendMoney(GetPrice(_bag.CurrentLevel - 1)))
        {
            _bag.IncreaseMaxCapacity();
        }
    }

    private void OnMaxLevelReached()
    {
        Destroy(gameObject);
    }
}
