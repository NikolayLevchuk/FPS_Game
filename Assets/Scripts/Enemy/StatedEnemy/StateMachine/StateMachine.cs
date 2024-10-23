using System.Collections.Generic;
using System.Linq;

public class StateMachine : IStateSwitcher
{
    private IState _currentState;
    private List<IState> _states;

    public StateMachine(EnemyContext enemyContext)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new PatrollingState(this, data, enemyContext),
            new ChasingState(this, data, enemyContext),
            new ShotingState(this, data, enemyContext)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState newState = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void HandleConditions() => _currentState.HandleConditions();
    public void Update() => _currentState.Update();    
}