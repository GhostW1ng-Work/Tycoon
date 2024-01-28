using Agava.YandexGames;
using System.Collections;
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

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();
    }
}
