using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _explosionRadius;
        [SerializeField] private int _damage;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private AudioClip _explosionClip;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>(); 
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IDamageble>(out IDamageble damageble))
            {
                Explosion();
            }    
        }

        private void Explosion()
        {
            _audioSource.PlayOneShot(_explosionClip);
            GameObject explosion = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IDamageble>(out var damageable))
                {
                    damageable.ApplyDamage(_damage);
                }
            }
            gameObject.GetComponent<Collider>().enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}