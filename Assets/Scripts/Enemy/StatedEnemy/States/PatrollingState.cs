using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : BaseState
{
    [SerializeField] private float _walkPointRange;

    private Vector3 _walkPoint; 
    private bool _isWalkPointSet;

    public PatrollingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
    }

    public override void Enter()
    {
        base.Enter();
        View.SetPatrollingAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        View.UnsetPatrollingAnimation();
    }

    public override void HandleConditions()
    {
        base.HandleConditions();
        if (PlayerDetector.PlayerInSightRange && !PlayerDetector.PlayerInShootingRange)
            StateSwitcher.SwitchState<ChasingState>();
    }

    public override void Update()
    {
        base.Update();
    }

    private void Patrolling()
    {

    }

    private void SearchForWalkingPoint()
    {
        float randXPos = Random.Range(-_walkPointRange, _walkPointRange);
        float randZPos = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(randXPos, Transform.position.y, randZPos);

        if (GroundDetector.Grounded)
            _isWalkPointSet = true;
    } 
}