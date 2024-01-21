using UnityEngine;

public class ItemSeller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBag bag))
        {
            if(bag.GetItemsCount() > 0 && bag.GetFirstItem().GetComponent<SellItem>())
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
    }
}
