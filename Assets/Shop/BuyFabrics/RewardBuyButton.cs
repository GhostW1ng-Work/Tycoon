using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RewardBuyButton : MonoBehaviour
{
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyTrigger _spawnPosition;
    [SerializeField] private ParticleSystem _system;
    [SerializeField] private float _offsetZ = 2;

    private Button _button;

    public event Action BuildingRewarded;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowReward);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowReward);
    }

    private void ShowReward()
    {
#if UNITY_WEBGL
        VideoAd.Show(onRewardedCallback: OnClick);
#endif
    }

    private void OnClick()
    {
            var forge = Instantiate(_banner.BuldTemplate, new Vector3(_spawnPosition.transform.position.x,
                _spawnPosition.transform.position.y, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 180, 0));

            Instantiate(_system, new Vector3(_spawnPosition.transform.position.x,
                _spawnPosition.transform.position.y + 1, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 0, 0));

            forge.transform.parent = null;
            BuildingRewarded?.Invoke();
    }


    public void SetBanner(Banner banner)
    {
        _banner = banner;
    }

    public void SetTrigger(BuyTrigger trigger)
    {
        _spawnPosition = trigger;
    }
}
