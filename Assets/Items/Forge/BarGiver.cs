using System.Collections.Generic;
using UnityEngine;

public class BarGiver : MonoBehaviour
{
    [SerializeField] private List<Bar> _bars;
    [SerializeField] private BarSpawners _spawner;

    public void AddBar(Bar bar)
    {
        _bars.Add(bar);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBag bag))
        {
            if (_bars.Count > 0)
            {
                bag.TryAddItem(_bars[_bars.Count - 1]);
                _bars.RemoveAt(_bars.Count - 1);
                _spawner.RemoveBar();

            }
        }
    }
}
