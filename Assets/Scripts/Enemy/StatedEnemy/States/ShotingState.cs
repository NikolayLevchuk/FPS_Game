using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingState : BaseState
{
    public ShotingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
    }
}
