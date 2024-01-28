using UnityEngine;

public class BuyTrigger : MonoBehaviour
{
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RewardBuyButton _rewardButton;
    [SerializeField] private bool _isAnvil;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            _rewardButton.SetBanner(_banner);
            _bannerShower.SetBanner(_banner);
            _rewardButton.SetTrigger(this);
            _buyButton.SetTrigger(this);
            SubcribeToOnBuildingBuyed();
            _bannerShower.EnablePanel();
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
}
