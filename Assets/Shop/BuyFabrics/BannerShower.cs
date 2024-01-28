using UnityEngine;
using TMPro;

public class BannerShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buyPanel;
    [SerializeField] private TMP_Text _buyText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RewardBuyButton _rewardButton;


    private void OnEnable()
    {
        _buyButton.BuildingBuyed += OnBuildingBuyed;
        _rewardButton.BuildingRewarded += OnBuildingBuyed;
    }

    private void OnDisable()
    {
        _buyButton.BuildingBuyed -= OnBuildingBuyed;
        _rewardButton.BuildingRewarded -= OnBuildingBuyed;
    }

    private void OnBuildingBuyed()
    {
        DisablePanel();
    }

    public void EnablePanel()
    {
        _buyPanel.alpha = 1;
        _buyPanel.blocksRaycasts = true;
        _buyPanel.interactable = true;
    }

    public void DisablePanel()
    {
        _buyPanel.alpha = 0;
        _buyPanel.blocksRaycasts = false;
        _buyPanel.interactable = false;
    }

    public void SetBanner(Banner banner)
    {
        _buyText.text = banner.BuyText;
        _priceText.text = $"{banner.Price} монеток";
        _buyButton.SetPrice(banner.Price);
        _buyButton.SetBanner(banner);
    }
}
