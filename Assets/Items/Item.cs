using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private bool _isPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBag bag) && _isPicked == false)
        {
            if (bag.TryAddItem(this))
            {
                _isPicked = true;
            }
        }   
    }
}
