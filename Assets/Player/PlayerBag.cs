using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] private Transform _bagTransform;
    [SerializeField] private int _maxCapacity;

    private List<Item> _items;

    private void Start()
    {
        _items = new List<Item>();
    }

    public void TryAddItem(Item item)
    {
        if (_items.Count < _maxCapacity)
        {
            item.transform.DOMove(_bagTransform.position, 0.1f).OnComplete(
                () =>
                {
                    item.transform.SetParent(_bagTransform, true);
                    item.transform.localPosition = new Vector3(0, 0.155f * _items.Count, 0);
                    item.transform.localRotation = Quaternion.Euler(item.RotationAfterCreate);
                }
                );
            _items.Add(item);
        }
    }

    public int GetItemsCount()
    {
        return _items.Count;
    }

    public Item GetFirstItem()
    {
        return _items[0];
    }

    public void RemoveItem()
    {
        if (_items.Count > 0)
        {
            _items[0].transform.DOMove(_bagTransform.position, 0.1f).OnComplete(
                () =>
                {
                    Destroy(_items[0].gameObject);
                    _items.RemoveAt(0);
                }
                );
        }

    }
}
