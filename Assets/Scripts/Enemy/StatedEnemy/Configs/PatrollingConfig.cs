using System;
using UnityEngine;

[Serializable]
public class PatrollingConfig : MonoBehaviour
{
    [SerializeField, Range(5,10)] private float _speed; 
    public float Speed => _speed; 
}