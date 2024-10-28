using Assets.Scripts;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _sightRange;
    [SerializeField] private float _shootingRange;
    [SerializeField] private LayerMask _whatIsPlayer;
    private PlayerController _player;

    private bool _playerInSightRange;
    private bool _playerInShootingRange;

    public bool PlayerInSightRange => _playerInSightRange;
    public bool PlayerInShootingRange => _playerInShootingRange;
    public PlayerController Player => _player;

    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _playerInShootingRange = Physics.CheckSphere(transform.position, _shootingRange, _whatIsPlayer);
        LookingForPlayer();
    }

    private void LookingForPlayer()
    {
        if (_playerInSightRange)
        {
            Collider[] playerCollider = Physics.OverlapSphere(transform.position, _sightRange, _whatIsPlayer);
            _player = playerCollider[0].GetComponent<PlayerController>();
        }
        else
        {
            _player = null;
        }
    }
}