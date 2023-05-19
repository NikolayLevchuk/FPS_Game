using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _whatIsGround, _whatIsPlayer;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private GameObject _shotEffect;
        [SerializeField] private float _shotPower;

        [Header("Ptrol")]
        [SerializeField] private Vector3 _walkPoint;
        bool _walkPointSet;
        [SerializeField] private float _walkPointRange;


        [Header("Attacking")]
        [SerializeField] private float _timeBetweenAttacks;
        bool _alreadyAttacked;

        [Header("Sounds")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shotSound;
 
        [Header("States")]
        [SerializeField] private float _sightRange, _attackRange;
        [SerializeField] private bool _playerInSightRange, _playerInAttackRange;

        private void Awake()
        {
            _player = GameObject.Find("Player").transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
            _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

            if (!_playerInSightRange && !_playerInAttackRange) Patroling();
            if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
            if (_playerInSightRange && _playerInAttackRange) AttackPlayer();
        }

        private void Patroling()
        {
            if (!_walkPointSet) SearchWalkPoint();

            if (_walkPointSet)
            {
                _agent.SetDestination(_walkPoint);
            }

            Vector3 distanceToWalkPoint = transform.position - _walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                _walkPointSet = false;
            }
        }

        private void SearchWalkPoint()
        {
            float randPointZ = Random.Range(-_walkPointRange, _walkPointRange);
            float randPointX = Random.Range(-_walkPointRange, _walkPointRange);

            _walkPoint = new Vector3(randPointX, transform.position.y, randPointZ);

            if (Physics.Raycast(_walkPoint, -transform.up, 2f, _whatIsGround))
                _walkPointSet = true;

        }

        private void ChasePlayer()
        {
            _agent.SetDestination(_player.position);
        }

        private void AttackPlayer()
        {
            _agent.SetDestination(transform.position);

            transform.LookAt(_player);

            if (!_alreadyAttacked)
            {
                _audioSource.PlayOneShot(_shotSound);
                GameObject shotEffect = Instantiate(_shotEffect, _attackPoint.position, _attackPoint.rotation);
                EnemysProjectile projectile = ObjectPool.instance.GetBullet();
                projectile.transform.position = _attackPoint.position;
                projectile.GetComponent<EnemysProjectile>().ProjcetileFly(transform.forward);

                _alreadyAttacked = true;
                Invoke(nameof(ResetAttack), _timeBetweenAttacks);
            }
        }

        private void ResetAttack()
        {
            _alreadyAttacked = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _sightRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}