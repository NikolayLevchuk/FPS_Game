using System;
using UnityEngine;

[Serializable]
public class ChasingConfig
{
    [SerializeField, Range(6, 10)] private float _speed;
    public float Speed => _speed;
}