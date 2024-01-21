using UnityEngine;

[CreateAssetMenu(fileName ="New Banner", menuName ="Banner")]
public class Banner : ScriptableObject
{
    [SerializeField] private string _buyText;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _buildTemplate;

    public string BuyText => _buyText;
    public int Price => _price;
    public GameObject BuldTemplate => _buildTemplate;
}
