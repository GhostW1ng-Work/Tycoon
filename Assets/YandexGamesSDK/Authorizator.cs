using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class Authorizator : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Authorize);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Authorize);
    }

    private void Authorize()
    {
        if(!PlayerAccount.IsAuthorized)
            PlayerAccount.Authorize();
    }
}
