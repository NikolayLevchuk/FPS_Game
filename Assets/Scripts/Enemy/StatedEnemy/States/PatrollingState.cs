using UnityEngine;

public class PatrollingState : BaseState
{
    private PatrollingConfig _config;

    private Vector3 _walkPoint;
    private bool _isWalkPointSet;

    public PatrollingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
        _config = enemyContext.Config.PatrollingConfig;
    }

    private float _speed => _config.Speed;
    private float _walkPointRange => _config.WalkPointRange;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _speed;
        Agent.speed = Data.Speed;
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
        Patrolling();
    }

    private void Patrolling()
    {
        Debug.Log("Patrolling method is executing");

        if (_isWalkPointSet == false)
            SearchForWalkingPoint();

        if (_isWalkPointSet == true)
            Agent.SetDestination(_walkPoint);

        if (DefineDistanceToWalkPoint(_walkPoint))
            _isWalkPointSet = false;
    }

    private bool DefineDistanceToWalkPoint(Vector3 walkPoint)
    {
        float distance = Vector3.Distance(Transform.position, walkPoint);
        bool arrivedAtTheDestinationPoint = distance < 0.1f;
        return arrivedAtTheDestinationPoint;
    }

    private void SearchForWalkingPoint()
    {
        float randXPos = Random.Range(-_walkPointRange, _walkPointRange);
        float randZPos = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(randXPos, Transform.position.y, randZPos);

        if (Grounded)
            _isWalkPointSet = true;
    }
}