using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemysProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public event Action<EnemysProjectile> Destroyed;

        public void ProjcetileFly(Vector3 direction)
        {
            _rb.velocity = direction * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageble damagable = other.GetComponent<IDamageble>();
            damagable?.ApplyDamage(_damage);
            Destroyed?.Invoke(this);
        }
    }
}