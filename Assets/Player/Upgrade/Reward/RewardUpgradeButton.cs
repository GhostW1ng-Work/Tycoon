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
#if !UNITY_EDITOR && UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
#else
        yield break;
#endif
    }
}
