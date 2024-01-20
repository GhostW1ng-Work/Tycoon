using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;

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
                    item.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }
                );
            _items.Add(item);
        }
    }

    public int RemoveItems()
    {
        int itemsCount = 0;
        foreach (var item in _items)
        {
            Destroy(item.gameObject);
            itemsCount++;
        }
        return itemsCount;
        _items.Clear();
    }
}
