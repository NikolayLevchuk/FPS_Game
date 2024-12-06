using Assets.Scripts;

public class ChasingState : BaseState
{
    private ChasingConfig _config;

    private DecisionTimeLogger _decisionTimeLogger;
    public ChasingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
        _config = enemyContext.Config.ChasingConfig;
        _decisionTimeLogger = enemyContext.GetComponent<DecisionTimeLogger>();
    }

    private float _speed => _config.Speed;
    private PlayerController _playerController => PlayerDetector.Player;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _speed;
        Agent.speed = Data.Speed;
        View.SetChasingState();
    }

    public override void Exit()
    {
        base.Exit();
        View.UnsetChasingState();
    }

    public override void HandleConditions()
    {
        base.HandleConditions();
        if (PlayerDetector.PlayerInShootingRange)
            StateSwitcher.SwitchState<ShootingState>();

        if (!PlayerDetector.PlayerInSightRange)
            StateSwitcher.SwitchState<PatrollingState>();
    }

    public override void Update()
    {
        base.Update();
        ChasePlayer();
        _decisionTimeLogger.LogDecisionTime("Chasing", ChasePlayer);

    }

    private void ChasePlayer()
    {
        Agent.SetDestination(PlayerDetector.Player.transform.position);
    }
}