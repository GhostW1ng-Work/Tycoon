using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Vector3 _startPosition;
    public ItemType ItemType => _itemType;
    public Vector3 StartPosition => _startPosition;
}
