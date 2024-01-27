using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class YandexInitializator : MonoBehaviour
{
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();
    }
}
