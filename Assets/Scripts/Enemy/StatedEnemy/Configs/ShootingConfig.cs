using System;
using UnityEngine;

[Serializable]
public class ShootingConfig
{
    [SerializeField, Range(0,0)] private float _speed;
    [SerializeField] private AudioClip _shootingSound; 
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private ParticleSystem _shootingEffect;
     
    public float Speed => _speed; 
    public AudioClip ShootingSound => _shootingSound;
    public float TimeBetweenShoots => _timeBetweenShoots;
    public ParticleSystem ShootingEffect => _shootingEffect;
}