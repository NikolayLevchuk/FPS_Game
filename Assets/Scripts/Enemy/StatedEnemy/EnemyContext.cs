using UnityEngine;
using UnityEngine.AI;

public class EnemyContext : MonoBehaviour
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private EnemyView _view;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private GroundDetector _groundDetector;
    private StateMachine _stateMachine;

    public bool Grounded => _groundDetector.Grounded;
    public Transform Transform => transform;
    public PlayerDetector PlayerDetector => _playerDetector;
    public EnemyView View => _view;
    public NavMeshAgent Agent => _agent; 
    public EnemyConfig Config => _config;

    private void Awake()
    {
        _stateMachine = new StateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleConditions();
        _stateMachine.Update(); 
    }
}