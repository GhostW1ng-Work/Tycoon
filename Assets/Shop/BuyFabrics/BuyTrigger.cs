using System;
using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class BuyTrigger : MonoBehaviour
{
    private const string IS_BUYED = "IsBuyed";

    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RewardBuyButton _rewardButton;
    [SerializeField] private bool _isAnvil;
    [SerializeField] private float _offsetZ;

    private int _isBuyed = 0;

    public static Action TriggerEntered;

    private IEnumerator Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        if (PlayerPrefs.HasKey(IS_BUYED+name))
        {
            _isBuyed = PlayerPrefs.GetInt(IS_BUYED+name);
            if(_isBuyed == 1)
            {
                Build();
            }
        }
        yield return YandexGamesSdk.Initialize();
#else
        if (PlayerPrefs.HasKey(IS_BUYED + name))
        {
            _isBuyed = PlayerPrefs.GetInt(IS_BUYED + name);
            if (_isBuyed == 1)
            {
                Build();
            }
        }
        yield break;
#endif
    }

    public void SubcribeToOnBuildingBuyed()
    {
        _buyButton.BuildingBuyed += OnBuildingBuyed;
        _rewardButton.BuildingRewarded += OnBuildingBuyed;
    }

    public void UnSubcribeToOnBuildingBuyed()
    {
        _buyButton.BuildingBuyed -= OnBuildingBuyed;
        _rewardButton.BuildingRewarded -= OnBuildingBuyed;
    }

    private void OnDisable()
    {
        _buyButton.BuildingBuyed -= OnBuildingBuyed;
        _rewardButton.BuildingRewarded -= OnBuildingBuyed;
    }

    private void OnBuildingBuyed()
    {
        Destroy(gameObject);
    }

    private void Build()
    {
        var forge = Instantiate(_banner.BuldTemplate, new Vector3(transform.position.x,
    transform.position.y, transform.position.z + _offsetZ), Quaternion.Euler(0, 180, 0));

        forge.transform.parent = null;
        Destroy(gameObject);
    }

    private void ShowPanel()
    {
        _rewardButton.SetBanner(_banner);
        _bannerShower.SetBanner(_banner);
        _rewardButton.SetTrigger(this);
        _buyButton.SetTrigger(this);
        SubcribeToOnBuildingBuyed();
        _bannerShower.EnablePanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            TriggerEntered?.Invoke();
            ShowPanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            _bannerShower.DisablePanel();
            UnSubcribeToOnBuildingBuyed();
        }
    }

    public void SetIsBuyed(int isBuyed)
    {
        _isBuyed = isBuyed;
        PlayerPrefs.SetInt(IS_BUYED + name, _isBuyed);
    }
}
