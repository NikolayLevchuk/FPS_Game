using UnityEngine;

namespace Assets.Scripts
{
    public class RocketForLauncher : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _radius;
        [SerializeField] private int _damage;
        [SerializeField] private GameObject _explosioEnffect;
        [SerializeField] private Collider _rocketCollider;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _exposionSound;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            RocketFly(transform.forward);
        }

        public void RocketFly(Vector3 direction)
        {
            _rb.velocity = direction * _speed;
        }

        private void RocketExplosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider collider in colliders)
            {
                IDamageble damagable = collider.GetComponent<IDamageble>();
                damagable?.ApplyDamage(_damage);
            }

            Instantiate(_explosioEnffect, transform.position, transform.rotation);
            _audioSource.PlayOneShot(_exposionSound);
        }

        private void OnDrawGizmos()
        {
            Color color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("BlockingWall"))
            {
                RocketExplosion();
                _rocketCollider.enabled = false;
                Invoke(nameof(DisableGameObject), 1.5f);
            }
        }
        
        private void DisableGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}