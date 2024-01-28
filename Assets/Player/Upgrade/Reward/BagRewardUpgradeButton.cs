using UnityEngine;

public class BagRewardUpgradeButton : RewardUpgradeButton
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
