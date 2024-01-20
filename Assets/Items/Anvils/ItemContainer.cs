using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private ItemCreator _itemCreator;

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBag bag) && _items.Count > 0)
        {
            bag.TryAddItem(_items[_items.Count - 1]);
            _items.RemoveAt(_items.Count - 1);
            _itemCreator.RemoveItem();
        }
    }
}
