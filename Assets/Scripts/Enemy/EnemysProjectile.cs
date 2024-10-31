using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemysProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Collider _collider;

        public event Action<EnemysProjectile> Destroyed;

        public void ProjcetileFly(Vector3 direction)
        {
            _rb.velocity = direction * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageble))
            {
                damageble.ApplyDamage(_damage);
            }

            Destroyed?.Invoke(this);

            DisableBullet();
        } 

        public void EnableBullet()
        {
            _meshRenderer.enabled = true;
            _collider.enabled = true;
        }

        public void DisableBullet()
        {
            _meshRenderer.enabled = false;
            _collider.enabled = false;

            Debug.Log("Bullet disabled");
        }
    }
}