using UnityEngine;
using UnityEngine.UI;
public class BuyButton : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;

    private int _price;
    private Button _button;

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
        _wallet.TrySpendMoney(_price);
    }

    public void SetPrice(int price)
    {
        _price = price;
    }

}
