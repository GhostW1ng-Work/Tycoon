using UnityEngine;

[CreateAssetMenu(fileName ="New Banner", menuName ="Banner")]
public class Banner : ScriptableObject
{
    [SerializeField] private string _buyTextEn;
    [SerializeField] private string _buyTextRu;
    [SerializeField] private string _buyTextTr;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _buildTemplate;

    public string BuyTextEn => _buyTextEn;
    public string BuyTextRu => _buyTextRu;
    public string BuyTextTr => _buyTextTr;
    public int Price => _price;
    public GameObject BuldTemplate => _buildTemplate;
}
