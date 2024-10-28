using System;
using UnityEngine;

[Serializable]
public class PatrollingConfig
{
    [SerializeField, Range(4,5)] private float _speed;
    [SerializeField, Range(5,10)] private float _walkPointRange;

    public float Speed => _speed; 
    public float WalkPointRange => _walkPointRange; 
}