using UnityEngine;
using DG.Tweening;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] private Transform _bagTransform;
    [SerializeField] private int _maxCapacity;

    private int _currentItems;

    public bool TryAddItem(Item item)
    {
        if (_currentItems < _maxCapacity)
        {

            item.transform.DOMove(_bagTransform.position, 0.1f).OnComplete(
                () =>
                {
                    item.transform.SetParent(_bagTransform, true);
                    item.transform.localPosition = new Vector3(0, 0.155f * _currentItems, 0);
                    item.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    _currentItems++;
                }
                );
            return true;
        }
        else
        {
            return false;
        }
    }
}
