using UnityEngine;
using TMPro;

public abstract class UpgradeTextUpdater : MonoBehaviour
{
    private const string MAX_LEVEL_REACHED = "MaxLevelReached";

    [SerializeField] protected TMP_Text LevelText;
    [SerializeField] protected TMP_Text PriceText;
    [SerializeField] protected UpgradeButton UpgradeButton;

    protected void Start()
    {
        if (!PlayerPrefs.HasKey(MAX_LEVEL_REACHED+name))
        {
            OnLevelIncreased();
        }
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }

    protected virtual void OnLevelIncreased()
    {
    }

    protected virtual void OnMaxLevelReached()
    {
        LevelText.text = "Max Level";
        PriceText.alpha = 0;
        PlayerPrefs.SetInt(MAX_LEVEL_REACHED+name, 1);
    }
}
