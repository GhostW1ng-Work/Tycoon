using UnityEngine;

[CreateAssetMenu(fileName ="AnvilLevel", menuName ="Create Anvil Level")]
public class AnvilLevel : ScriptableObject
{
    [SerializeField] private string _buyText;
    [SerializeField] private string _priceText;
    [SerializeField] private int _price;
    [SerializeField] private Material _newMaterial;

    public string BuyText => _buyText;
    public string PriceText => _priceText;
    public int Price => _price;
    public Material NewMaterial => _newMaterial;
}
