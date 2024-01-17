using UnityEngine;

public class AnvilUpgrader : MonoBehaviour
{
    [SerializeField] private MeshRenderer _anvilMeshRenderer;
    [SerializeField] private AnvilLevel[] _levels;
    [SerializeField] private BannerShower _bannerShower;
    [SerializeField] private BuyButton _buyButton;

    private int _currentLevel = 1;

    private void OnDisable()
    {
        _buyButton.AnvilUpgraded -= OnAnvilUpgraded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet playerWallet))
        {
            _bannerShower.SetAnvilLevel(_levels[_currentLevel - 1]);
            _bannerShower.EnablePanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet playerWallet))
        {
            _bannerShower.DisablePanel();
        }
    }

    private void OnAnvilUpgraded()
    {
        _anvilMeshRenderer.material = _levels[_currentLevel - 1].NewMaterial;
        _currentLevel++;
        if(_currentLevel > _levels.Length)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(BannerShower shower, BuyButton button)
    {
        _bannerShower = shower;
        _buyButton = button;
        _buyButton.AnvilUpgraded += OnAnvilUpgraded;
    }
}
