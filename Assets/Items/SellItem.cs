using UnityEngine;

public class SellItem : Item
{
    [SerializeField] private int _price;
    public int Price => _price;
}
