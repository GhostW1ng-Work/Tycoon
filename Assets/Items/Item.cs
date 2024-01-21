using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Vector3 _rotationAfterCreate;
    [SerializeField] private int[] _prices;

    private int _currentPrice;

    public ItemType ItemType => _itemType;
    public Vector3 StartPosition => _startPosition;
    public int CurrentPrice => _currentPrice;
    public Vector3 RotationAfterCreate => _rotationAfterCreate;

    public void SetItemtype(Material material, ItemType itemType)
    {
        _currentPrice = _prices[(int)itemType];
        _itemType = itemType;
        _meshRenderer.material = material;
    }
}
