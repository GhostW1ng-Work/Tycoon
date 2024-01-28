using System;
using UnityEngine;
using UnityEngine.UI;


public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] protected PlayerWallet Wallet;
    [SerializeField] private int[] _prices;

    protected Button Button;
    protected int CurrentLevel = 0;

    public Action LevelIncreased;
    public Action MaxLevelReached;

    public int PublicCurrentLevel => CurrentLevel;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    public int GetPrice(int index)
    {
        return _prices[index];
    }

    public int GetCurrentLevel()
    {
        return CurrentLevel;
    }

    public void IncreaseCurrentLevel()
    {
        CurrentLevel++;
    }
}
