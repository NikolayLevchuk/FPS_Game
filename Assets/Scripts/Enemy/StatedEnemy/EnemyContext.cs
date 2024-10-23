using UnityEngine;
using UnityEngine.AI;

public class EnemyContext : MonoBehaviour
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private GroundDetector _groundDetector;
    private StateMachine _stateMachine;

    public GroundDetector GroundDetector => _groundDetector;
    public Transform Transform => transform;
    public PlayerDetector PlayerDetector => _playerDetector;
    public EnemyView View => _view;
    public NavMeshAgent Agent => _agent; 

    private void Awake()
    {
        
    }
}