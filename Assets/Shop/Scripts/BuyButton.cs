using System;
using UnityEngine;
using UnityEngine.UI;



public class BuyButton : MonoBehaviour
{
    public enum BuyTypes
    {
        Buy,
        BuyAnvil,
        Upgrade
    }

    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyTrigger _spawnPosition;
    [SerializeField] private float _offsetZ = 2;

    private BuyTypes _type;
    private int _price;
    private Button _button;

    public event Action BuildingBuyed;
    public event Action AnvilUpgraded;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_wallet.TrySpendMoney(_price))
        {
            switch (_type)
            {
                case BuyTypes.Buy:
                    if (_wallet.TrySpendMoney(_price))
                    {
                        var forge = Instantiate(_banner.BuldTemplate, new Vector3(_spawnPosition.transform.position.x,
                            _spawnPosition.transform.position.y, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 180, 0));
                        forge.transform.parent = null;
                        BuildingBuyed?.Invoke();
                    }
                    break;
                case BuyTypes.BuyAnvil:
                    var anvil = Instantiate(_banner.BuldTemplate, new Vector3(_spawnPosition.transform.position.x,
    _spawnPosition.transform.position.y, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 180, 0));
                    BuildingBuyed?.Invoke();
                    break;
                case BuyTypes.Upgrade:
                    AnvilUpgraded?.Invoke();
                    break;
            }
        }
    }

    public void SetPrice(int price)
    {
        _price = price;
    }

    public void SetBanner(Banner banner)
    {
        _banner = banner;
    }

    public void SetTrigger(BuyTrigger trigger)
    {
        _spawnPosition = trigger;
    }

    public void SetBuyType(BuyTypes type)
    {
        _type = type;
    }
}
