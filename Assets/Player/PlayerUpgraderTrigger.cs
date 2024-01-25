using UnityEngine;

public class PlayerUpgraderTrigger : MonoBehaviour
{
    [SerializeField] private CanvasGroup _upgradePanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            EnablePanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisablePanel();
    }

    private void EnablePanel()
    {
        _upgradePanel.alpha = 1;
        _upgradePanel.blocksRaycasts = true;
        _upgradePanel.interactable = true;
    }

    private void DisablePanel()
    {
        _upgradePanel.alpha = 0;
        _upgradePanel.blocksRaycasts = false;
        _upgradePanel.interactable = false;
    }
}
