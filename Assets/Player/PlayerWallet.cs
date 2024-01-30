using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private const string COINS_COUNT = "CoinsCount";
    private int _coinsCount = 15000;

    public int CoinsCount => _coinsCount;

    public Action CoinsAdded;

    private void Start()
    {
        if (PlayerPrefs.HasKey(COINS_COUNT))
        {
            _coinsCount = PlayerPrefs.GetInt(COINS_COUNT);
            CoinsAdded?.Invoke();
        }
    }

    public bool TrySpendMoney(int spendAmount)
    {
        if (_coinsCount >= spendAmount)
        {
            _coinsCount -= spendAmount;
            PlayerPrefs.SetInt(COINS_COUNT, _coinsCount);
            PlayerPrefs.Save();
            CoinsAdded?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddMoney(int addAmount)
    {
        if (addAmount > 0)
        {
            _coinsCount += addAmount;
            PlayerPrefs.SetInt(COINS_COUNT, _coinsCount);
            PlayerPrefs.Save();
            CoinsAdded?.Invoke();
        }
    }
}
