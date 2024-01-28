using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedRewardUpgrade : RewardUpgradeButton
{
    [SerializeField] private PlayerMover _mover;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnUpgrade);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnUpgrade);
    }

    private void OnUpgrade()
    {

        if (_mover.CurrentLevel >= _mover.MaxLevel)
        {
            Upgrade.MaxLevelReached?.Invoke();
            Destroy(Upgrade.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Upgrade.IncreaseCurrentLevel();
            Upgrade.LevelIncreased?.Invoke();
            _mover.IncreaseMoveSpeed();
            if (_mover.CurrentLevel >= _mover.MaxLevel)
            {
                Upgrade.MaxLevelReached?.Invoke();
                Destroy(Upgrade.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
