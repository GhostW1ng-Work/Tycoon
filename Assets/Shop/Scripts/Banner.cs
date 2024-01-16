using UnityEngine;

[CreateAssetMenu(fileName ="New Banner", menuName ="Banner")]
public class Banner : ScriptableObject
{
    [SerializeField] private string _buyText;
    [SerializeField] private string _priceText;

    public string BuyText => _buyText;
    public string PriceText => _priceText;
}
