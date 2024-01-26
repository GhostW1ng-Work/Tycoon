using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Banner _banner;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyTrigger _spawnPosition;
    [SerializeField] private ParticleSystem _system;
    [SerializeField] private float _offsetZ = 2;

    private int _price;
    private Button _button;

    public event Action BuildingBuyed;

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
            var forge = Instantiate(_banner.BuldTemplate, new Vector3(_spawnPosition.transform.position.x,
                _spawnPosition.transform.position.y, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 180, 0));

            Instantiate(_system, new Vector3(_spawnPosition.transform.position.x,
                _spawnPosition.transform.position.y + 1, _spawnPosition.transform.position.z + _offsetZ), Quaternion.Euler(0, 0, 0));

            forge.transform.parent = null;
            BuildingBuyed?.Invoke();
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
}
