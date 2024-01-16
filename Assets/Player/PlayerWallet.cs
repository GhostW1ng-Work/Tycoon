using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coinsCount;

    public void SpendMoney(int spendAmount)
    {
        if(_coinsCount >= spendAmount)
        {
            _coinsCount -= spendAmount;
        }
    }

    public void AddMoney(int addAmount)
    {
        if(addAmount > 0)
            _coinsCount += addAmount;
    }
}
