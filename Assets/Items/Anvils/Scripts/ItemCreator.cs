using UnityEngine;
using DG.Tweening;
public class ItemCreator : MonoBehaviour
{
    [SerializeField] private Bar _bar;
    [SerializeField] private Item _craftItem;
    [SerializeField] private ItemContainer _container;
    [SerializeField] private Transform _itemPosition;
    [SerializeField] private int _maxItemsCount;
    [SerializeField] private Material[] _materials;

    private int _currentItemsCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBag bag))
        {
            if(_currentItemsCount < _maxItemsCount && bag.GetItemsCount() > 0)
            {
                if(bag.GetFirstItem().GetType() == _bar.GetType())
                {
                    CraftItem(bag.GetFirstItem().GetComponent<Bar>());
                    bag.RemoveItem();
                }
            }
        }
    }

    private void CraftItem(Bar bar)
    {
        _currentItemsCount++;
        var newItem = Instantiate(_craftItem, new Vector3
            (_itemPosition.position.x,
            _craftItem.StartPosition.y * _currentItemsCount,
            _itemPosition.position.z), Quaternion.Euler(_craftItem.RotationAfterCreate));
        newItem.SetItemtype(_materials[(int)bar.ItemType], bar.ItemType);
        _container.AddItem(newItem);
    }

    public void RemoveItem()
    {
        _currentItemsCount--;
    }
}
