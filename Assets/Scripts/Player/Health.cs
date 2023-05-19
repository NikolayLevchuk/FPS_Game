using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour, IDamageble
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private HealthBar _healthBar;
        private int _currentHealth;

        public event Action PlayerDead;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if(value >= _maxHealth)
                {
                    _currentHealth = _maxHealth;
                }
                _currentHealth = value;
                _healthBar.SetHealth(_currentHealth);
            }
        }

        void Start()
        {
            _currentHealth = _maxHealth;
            _healthBar.SetMaxHealth(_maxHealth);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                PlayerDead?.Invoke();
                transform.gameObject.SetActive(false);
            }
        }
    }
}
