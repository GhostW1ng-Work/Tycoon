using UnityEngine;

public class BuyTrigger : MonoBehaviour
{
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            _bannerShower.SetBanner(_banner);
            _bannerShower.EnablePanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            _bannerShower.DisablePanel();
        }
    }
}