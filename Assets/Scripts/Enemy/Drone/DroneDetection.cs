using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class DroneDetection : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius;
        [SerializeField] private bool _playerDetected;
        [SerializeField] private LayerMask _whatIsTarget;
        [SerializeField] private Transform _target;
        [SerializeField] private Rigidbody _rb;

        public Transform Target => _target;

        public event Action FoundTarget;
        public event Action GotTargetPosition;

        private void Update()
        {
            ScanTerritory();
        }

        private void ScanTerritory()
        {
            _playerDetected = Physics.CheckSphere(transform.position, _detectionRadius, _whatIsTarget);
            if (_playerDetected == true)
            {
                FoundTarget?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GotTargetPosition?.Invoke();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }
    }
}