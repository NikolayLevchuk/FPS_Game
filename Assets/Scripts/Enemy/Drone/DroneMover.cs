using Assets.Scripts;
using System;
using UnityEngine;

public class DroneMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DroneDetection _detection;
    [SerializeField] private float _attackDistance;

    private bool _chasing = false;

    private void OnEnable()
    {
        _detection.FoundTarget += ChasePlayer;
    }

    private void OnDisable()
    {
        _detection.FoundTarget -= ChasePlayer;
    }

    void FixedUpdate()
    {
        if (_chasing == false )
            _rb.velocity = transform.forward * _moveSpeed;
        else
            ChasePlayer();
    }

    private void ChasePlayer()
    {
        _chasing = true;


        Vector3 direction = _detection.Target.position - transform.position;


        Vector3 targetPos = _detection.Target.position;
        Vector3 targetDirection = new Vector3(direction.x, 0f, direction.z).normalized;

        _rb.velocity = targetDirection.normalized * _moveSpeed;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed);
    }

}
