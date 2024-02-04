using UnityEngine;
using TMPro;
using Agava.YandexGames;
using System.Collections;

public class BannerShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buyPanel;
    [SerializeField] private TMP_Text _buyText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RewardBuyButton _rewardButton;

    private IEnumerator Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
#else
        yield break;
#endif
    }

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
        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "en":
                _buyText.text = banner.BuyTextEn;
                _priceText.text = $"{banner.Price} coins";
                break;
            case "ru":
                _buyText.text = banner.BuyTextRu;
                _priceText.text = $"{banner.Price} монеток";
                break;
            case "tr":
                _buyText.text = banner.BuyTextTr;
                _priceText.text = $"{banner.Price} coins";
                break;
            default:
                _buyText.text = banner.BuyTextEn;
                _priceText.text = $"{banner.Price} coins";
                break;
        }
        _buyButton.SetPrice(banner.Price);
        _buyButton.SetBanner(banner);
    }
}
