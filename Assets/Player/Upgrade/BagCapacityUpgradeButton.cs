using UnityEngine;

public class BagCapacityUpgradeButton : UpgradeButton
{
    [SerializeField] private PlayerBag _bag;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnUpgrade);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnUpgrade);
    }

    private void OnUpgrade()
    {
        if(_bag.CurrentLevel >= _bag.MaxLevel)
        {
            MaxLevelReached?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            if(Wallet.TrySpendMoney(GetPrice(_bag.CurrentLevel - 1)))
            {
                CurrentLevel++;
                LevelIncreased?.Invoke();
                _bag.IncreaseMaxCapacity();
                if (_bag.CurrentLevel >= _bag.MaxLevel)
                {
                    MaxLevelReached?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
