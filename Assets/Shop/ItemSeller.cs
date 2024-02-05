using UnityEngine;
using Agava.YandexGames;
using System.Collections;

public class ItemSeller : MonoBehaviour
{
    private const string EARNED_MONEY = "earnedMoney";
    private const string CURRENT_EARNED_MONEY = "currentEarnedMoney";

    private int _currentEarnedMoney = 0;

    private IEnumerator Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
        if(PlayerPrefs.HasKey(CURRENT_EARNED_MONEY))
        {
            _currentEarnedMoney = PlayerPrefs.GetInt(CURRENT_EARNED_MONEY);
        }
#else
        if (PlayerPrefs.HasKey(CURRENT_EARNED_MONEY))
        {
            _currentEarnedMoney = PlayerPrefs.GetInt(CURRENT_EARNED_MONEY);
        }
        yield break;
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBag bag))
        {
            if (bag.GetItemsCount() > 0 && bag.GetFirstItem().GetComponent<SellItem>())
            {
                SellItem(bag);
            }
        }
    }

    private void SellItem(PlayerBag bag)
    {
        PlayerWallet wallet = bag.GetComponent<PlayerWallet>();
        wallet.AddMoney(bag.GetFirstItem().CurrentPrice);
        bag.RemoveItem();
        _currentEarnedMoney += bag.GetFirstItem().CurrentPrice;
        PlayerPrefs.SetInt(CURRENT_EARNED_MONEY, _currentEarnedMoney);
        PlayerPrefs.Save();
        Leaderboard.SetScore(EARNED_MONEY, bag.GetFirstItem().CurrentPrice);

    }
}
