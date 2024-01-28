using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _settingsPanel;
    [SerializeField] private PlayerUpgraderTrigger _upgraderTrigger;

    private Button _button;
    private bool _isActive = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _upgraderTrigger.TriggerEntered += DisablePanel;
        BuyTrigger.TriggerEntered += DisablePanel;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _upgraderTrigger.TriggerEntered -= DisablePanel;
        BuyTrigger.TriggerEntered -= DisablePanel;
    }

    private void OnClick()
    {
        if (_isActive)
            DisablePanel();
        else
            EnablePanel();
    }

    private void EnablePanel()
    {
        _isActive = true;
        _settingsPanel.alpha = 1;
        _settingsPanel.blocksRaycasts = true;
        _settingsPanel.interactable = true;
    }

    private void DisablePanel()
    {
        _isActive = false;
        _settingsPanel.alpha = 0;
        _settingsPanel.blocksRaycasts = false;
        _settingsPanel.interactable = false;
    }
}
