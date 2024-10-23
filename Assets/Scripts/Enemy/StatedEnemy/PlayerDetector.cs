using UnityEngine;

public class PlayerDetector : MonoBehaviour 
{
    [SerializeField] private float _sightRange;
    [SerializeField] private float _shootingRange; 

    private bool _playerInSightRange;
    private bool _playerInShootingRange;
     
    public bool PlayerInSightRange => _playerInSightRange;
    public bool PlayerInShootingRange => _playerInShootingRange;

    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange);
        _playerInShootingRange = Physics.CheckSphere(transform.position, _shootingRange);
    }
}