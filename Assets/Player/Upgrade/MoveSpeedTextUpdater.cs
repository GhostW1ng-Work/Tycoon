using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedTextUpdater : UpgradeTextUpdater
{
    [SerializeField] private PlayerMover _mover;

    protected override void OnEnable()
    {
        _mover.LevelIncreased += OnLevelIncreased;
        _mover.MaxLevelReached += OnMaxLevelReached;
    }

    protected override void OnDisable()
    {
        _mover.LevelIncreased -= OnLevelIncreased;
        _mover.MaxLevelReached -= OnMaxLevelReached;
    }

    protected override void OnLevelIncreased()
    {
        LevelText.text = _mover.CurrentLevel.ToString();
        PriceText.text = UpgradeButton.GetPrice(_mover.CurrentLevel - 1).ToString();
    }
}
