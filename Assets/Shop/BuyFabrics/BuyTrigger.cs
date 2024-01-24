using UnityEngine;

public class BuyTrigger : MonoBehaviour
{
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private bool _isAnvil;

    public void SubcribeToOnBuildingBuyed()
    {
        _buyButton.BuildingBuyed += OnBuildingBuyed;
    }

    public void UnSubcribeToOnBuildingBuyed()
    {
        _buyButton.BuildingBuyed -= OnBuildingBuyed;
    }

    private void OnDisable()
    {
        _buyButton.BuildingBuyed -= OnBuildingBuyed;
    }

    private void OnBuildingBuyed()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            _bannerShower.SetBanner(_banner);
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
