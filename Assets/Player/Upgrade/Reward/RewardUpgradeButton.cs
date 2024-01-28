using UnityEngine;
using UnityEngine.UI;

public abstract class RewardUpgradeButton : MonoBehaviour
{
    [SerializeField] protected UpgradeButton Upgrade;

    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }
}
