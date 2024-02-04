using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] protected PlayerWallet Wallet;
    [SerializeField] protected UpgradeButton UpButton;
    [SerializeField] private int[] _prices;

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

    public int GetPrice(int index)
    {
        return _prices[index];
    }
}
