using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coinsCount = 1000;

    public void TrySpendMoney(int spendAmount)
    {
        if(_coinsCount >= spendAmount)
        {
            _coinsCount -= spendAmount;
        }
        else
        {
            print("Бабла недостаточно");
        }
    }

    public void AddMoney(int addAmount)
    {
        if(addAmount > 0)
            _coinsCount += addAmount;
    }
}
