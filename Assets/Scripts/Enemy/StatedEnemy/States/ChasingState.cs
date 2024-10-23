using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : BaseState
{
    public ChasingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
    }
}