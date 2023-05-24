using UnityEngine;

namespace Assets.Scripts
{
    public class DroneHealth : MonoBehaviour, IDamageble
    {
        [SerializeField] private int _maxHp;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private AudioClip _explosionSound;
        private int _currentHp;

        private void Start()
        {
            _currentHp = _maxHp;
        }

        public void ApplyDamage(int damage)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(_explosionSound);
                Instantiate(_explosionEffect, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}