using UnityEngine;

public class MaxSpeedUpgrader : UpgradeButton
{
    [SerializeField] private PlayerMover _mover;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnUpgrade);
        _mover.MaxLevelReached += OnMaxLevelReached;
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnUpgrade);
        _mover.MaxLevelReached -= OnMaxLevelReached;
    }

    private void OnUpgrade()
    {
        if (Wallet.TrySpendMoney(GetPrice(_mover.CurrentLevel - 1)))
        {
            _mover.IncreaseMoveSpeed();
        }
    }

    private void OnMaxLevelReached()
    {
        Destroy(gameObject);
    }
}
