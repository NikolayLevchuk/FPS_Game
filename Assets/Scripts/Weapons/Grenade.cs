using Assets.Scripts.Weapons;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Grenade : MonoBehaviour, INonReloadable
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private int _damage;
        [SerializeField] private float _throwPower;
        [SerializeField] private float _radius;
        [SerializeField] private int _grenadesLeft = 1;
        [SerializeField] private int _grenadesAmount = 1;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _grenadeTransform;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _explosionSound;

        public event Action Shot;

        public int CurrentRounds => _grenadesLeft;
        public int RoundsAmount => _grenadesAmount;
        public int AllRounds => _grenadesLeft;

        void Update()
        {
            CheckInputs();
        }

        private void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _grenadesLeft > 0)
            {
                ThrowGrenade();
            }
        }

        private void ThrowGrenade()
        {
            transform.SetParent(null);
            _rb.isKinematic = false;
            _grenadesLeft--;
            Shot?.Invoke();
            _rb.AddForce(transform.forward * _throwPower, ForceMode.Impulse);
            Invoke(nameof(GrenadeExplosion), 2f);
        }

        private void GrenadeExplosion()
        {
            _audioSource.PlayOneShot(_explosionSound);
            GameObject explosionEffect = Instantiate(_explosionEffect, _grenadeTransform.position, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(_grenadeTransform.position, _radius);
            foreach (Collider collider in colliders)
            {
                IDamageble damagable = collider.GetComponent<IDamageble>();
                damagable?.ApplyDamage(_damage);
            }
            _collider.enabled = false;
            _meshRenderer.enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_grenadeTransform.position, _radius);
        }
    }
}