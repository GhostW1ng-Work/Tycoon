using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class YandexInitializator : MonoBehaviour
{
    private IEnumerator Start()
    {
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
        print(name);
        yield break;
#endif
    }
}
