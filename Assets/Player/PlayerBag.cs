using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;

public class PlayerBag : MonoBehaviour
{
    private const string CURRENT_LEVEL_CAPACITY = "CurrentLevelCapacity";

    [SerializeField] private Transform _bagTransform;
    [SerializeField] private int _maxCapacity;

    private List<Item> _items;

    private int _currentLevel = 1;
    private int _maxLevel = 6;

    public int CurrentLevel => _currentLevel;
    public int MaxLevel => _maxLevel;

    public Action LevelIncreased;
    public Action MaxLevelReached;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(CURRENT_LEVEL_CAPACITY))
        {
            _currentLevel = PlayerPrefs.GetInt(CURRENT_LEVEL_CAPACITY);
            _maxCapacity += _currentLevel;
            if(_currentLevel >= _maxLevel)
            {
                MaxLevelReached?.Invoke();
            }
            else
            {
                LevelIncreased?.Invoke();
            }

        }
    }

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

    public void IncreaseMaxCapacity()
    {
        _currentLevel++;
        _maxCapacity++;
        PlayerPrefs.SetInt(CURRENT_LEVEL_CAPACITY, _currentLevel);
        if(_currentLevel >= _maxLevel)
        {
            MaxLevelReached?.Invoke();
        }
        else
        {
            LevelIncreased?.Invoke();
        }
    }
}
