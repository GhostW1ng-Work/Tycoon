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
#if !UNITY_EDITOR && UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "ru":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "en":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
                break;
            case "tr":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Turkish");
                break;
        }
#else
        yield break;
#endif
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
