using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class InterstitialAdShower : MonoBehaviour
{
    [SerializeField] private float _minAdTime;
    [SerializeField] private float _maxAdTime;

    private float _currentAdTime = 0;
    private IEnumerator Start()
    {
        _currentAdTime = Random.Range(_minAdTime, _maxAdTime);
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();
    }

    private void Update()
    {
        if(_currentAdTime > 0)
        {
            _currentAdTime -= Time.deltaTime;
        }
        else
        {
            InterstitialAd.Show();
            _currentAdTime = Random.Range(_minAdTime, _maxAdTime);
        }
    }
}
