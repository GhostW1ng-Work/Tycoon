using UnityEngine;

public class MaxSpeedUpgrader : UpgradeButton
{
    [SerializeField] private PlayerMover _mover;

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
        if (_mover.CurrentLevel >= _mover.MaxLevel)
        {
            MaxLevelReached?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            if (Wallet.TrySpendMoney(GetPrice(_mover.CurrentLevel - 1)))
            {
                CurrentLevel++;
                LevelIncreased?.Invoke();
                _mover.IncreaseMoveSpeed();
                if (_mover.CurrentLevel >= _mover.MaxLevel)
                {
                    MaxLevelReached?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
