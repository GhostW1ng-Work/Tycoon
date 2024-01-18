using UnityEngine;

public class BarSpawners : MonoBehaviour
{
    [SerializeField] private Bar _bar;
    [SerializeField] private BarGiver _giver;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private int _maxItemsCount;

    private float _currentSpawnTime = 0;
    private int _currentItemsCount = 0;

    private void Start()
    {
        _currentSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void Update()
    {
        if(_currentSpawnTime > 0 && _currentItemsCount < _maxItemsCount)
        {
            _currentSpawnTime -= Time.deltaTime;
            if(_currentSpawnTime <= 0)
            {
                Bar bar = Instantiate(_bar, new Vector3
                    (_spawnPoint.position.x,0.155f * _currentItemsCount, _spawnPoint.position.z), Quaternion.identity);
                _giver.AddBar(bar);
                _currentItemsCount++;
                _currentSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            }
        }
    }

    public void RemoveBar()
    {
        _currentItemsCount--;
    }
}
