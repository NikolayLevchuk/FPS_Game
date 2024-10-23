using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private string _patrollingAnimatorKey;
    [SerializeField] private string _chasingAnimatorKey;
    [SerializeField] private string _shootingAnimatorKey;

    public void SetPatrollingAnimation() => _animator.SetBool(_patrollingAnimatorKey, true);
    public void SetChasingState() => _animator.SetBool(_chasingAnimatorKey, true);
    public void SetShootingState() => _animator.SetBool(_shootingAnimatorKey, true);

    public void UnsetPatrollingAnimation() => _animator.SetBool(_patrollingAnimatorKey, false);
    public void UnsetChasingState() => _animator.SetBool(_chasingAnimatorKey, false);
    public void UnsetShootingState() => _animator.SetBool(_shootingAnimatorKey, false);
}