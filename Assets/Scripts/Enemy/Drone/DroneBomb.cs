using UnityEngine;

namespace Assets.Scripts
{
    public class DroneBomb : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _smooth;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private float _radius;
        [SerializeField] private AudioClip _explosionSound;
        private AudioSource _audioSource;

        private Vector3 _rotationTo;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _rotationTo = new Vector3(180, 0, 0);
        }
        void Update()
        {
            RightRotaion();
        }
        private void Detonate()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (Collider member in colliders)
            {
                IDamageble damageble = member.GetComponent<IDamageble>();
                damageble?.ApplyDamage(_damage);
            }
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(_explosionSound);
            gameObject.GetComponent<DroneBomb>().enabled = false;
            Invoke(nameof(DisableBomb), 2f);
        }
        private void RightRotaion()
        {
            _rb.isKinematic = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_rotationTo), _smooth);
        }

        private void DisableBomb()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Detonate();
        }
    }
}