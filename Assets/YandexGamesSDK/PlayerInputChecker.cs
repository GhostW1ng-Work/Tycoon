using Agava.WebUtility;
using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class PlayerInputChecker : MonoBehaviour
{
    [Header("MobileMovement")]
    [SerializeField] private FloatingJoystick _joystick;

    private IEnumerator Start()
    {
#if UNITY_EDITOR || !UNITY_WEBGL
        if (SystemInfo.deviceType == UnityEngine.DeviceType.Desktop)
        {
            _joystick.gameObject.SetActive(false);
        }
        yield break;
#else
        yield return YandexGamesSdk.Initialize();

        if (!Device.IsMobile)
        {
            _joystick.gameObject.SetActive(false);
        }
#endif
    }
}
