using UnityEngine;
using TMPro;

public class CoinsUpdater : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        OnCoinsAdded();
    }

    private void OnEnable()
    {
        _playerWallet.CoinsAdded += OnCoinsAdded;
    }

    private void OnDisable()
    {
        _playerWallet.CoinsAdded -= OnCoinsAdded;
    }

    private void OnCoinsAdded()
    {
            _text.text = _playerWallet.CoinsCount.ToString();
    }
}
