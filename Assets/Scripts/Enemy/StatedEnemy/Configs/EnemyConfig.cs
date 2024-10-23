using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private PatrollingConfig _patrollingConfig; 
    [SerializeField] private ChasingConfig _chasingConfig;
    [SerializeField] private ShootingConfig _shootingConfig;

    public PatrollingConfig PatrollingConfig => _patrollingConfig;
    public ChasingConfig ChasingConfig => _chasingConfig;
    public ShootingConfig ShootingConfig => _shootingConfig;
} 