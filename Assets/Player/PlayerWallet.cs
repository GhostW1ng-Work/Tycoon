using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coinsCount = 100000;

    public int CoinsCount => _coinsCount;

    public Action CoinsAdded;

    public bool TrySpendMoney(int spendAmount)
    {
        if(_coinsCount >= spendAmount)
        {
            _coinsCount -= spendAmount;
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
        if(addAmount > 0)
        {
            _coinsCount += addAmount;
            CoinsAdded?.Invoke();
        }
    }
}
