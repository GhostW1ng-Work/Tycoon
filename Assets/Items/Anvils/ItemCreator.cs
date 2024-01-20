using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private Bar _bar;
    [SerializeField] private Item _craftItem;
    [SerializeField] private ItemContainer _container;
    [SerializeField] private Transform _itemPosition;
    [SerializeField] private int _resourcesCount;

    private int _currentItemsCount;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBag bag))
        {
            CraftItem(bag.RemoveItems());
        }
    }

    private void CraftItem(int itemsCount)
    {
        for (int i = 0; i < itemsCount; i++)
        {
            _currentItemsCount++;
            var newItem = Instantiate(_craftItem, new Vector3
                (_itemPosition.position.x,
                _craftItem.StartPosition.y * _currentItemsCount,
                _itemPosition.position.z), Quaternion.identity);
            _container.AddItem(newItem);
        }
    }

    public void RemoveItem()
    {
        _currentItemsCount--;
    }
}
