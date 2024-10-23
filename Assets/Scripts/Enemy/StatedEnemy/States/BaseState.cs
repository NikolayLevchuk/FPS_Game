using UnityEngine;
using UnityEngine.AI;

public class BaseState : IState
{
    protected IStateSwitcher StateSwitcher; 
    protected StateMachineData Data;
    protected EnemyContext _enemyContext;
    
    public BaseState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext)
    {
        StateSwitcher = switcher;
        Data = data;
        _enemyContext = enemyContext;
    } 

    protected Transform Transform => _enemyContext.Transform; 
    protected NavMeshAgent Agent => _enemyContext.Agent;
    protected PlayerDetector PlayerDetector => _enemyContext.PlayerDetector;
    protected GroundDetector GroundDetector => _enemyContext.GroundDetector;
    protected EnemyView View => _enemyContext.View;

    public virtual void Enter()
    {
        Debug.Log($"Entered in {GetType()}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Left from {GetType()}");
    }

    public virtual void HandleConditions()
    {
        
    }

    public virtual void Update()
    {
        
    }
}