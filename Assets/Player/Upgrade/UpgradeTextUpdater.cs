using UnityEngine;
using TMPro;

public class UpgradeTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private UpgradeButton _upgradeButton;

    private void Start()
    {
        OnLevelIncreased();
    }

    private void OnEnable()
    {
        _upgradeButton.LevelIncreased += OnLevelIncreased;
        _upgradeButton.MaxLevelReached += OnMaxLevelReached;
    }

    private void OnDisable()
    {
        _upgradeButton.LevelIncreased -= OnLevelIncreased;
        _upgradeButton.MaxLevelReached -= OnMaxLevelReached;
    }

    private void OnLevelIncreased()
    {
        _levelText.text = (_upgradeButton.GetCurrentLevel() + 1).ToString();
        _priceText.text = _upgradeButton.GetPrice(_upgradeButton.GetCurrentLevel()).ToString();
    }

    private void OnMaxLevelReached()
    {
        _levelText.text = "Max Level";
        _priceText.alpha = 0;
    }
}
