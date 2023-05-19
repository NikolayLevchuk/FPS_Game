using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyHealth : MonoBehaviour, IDamageble, IEnemieble
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private EnemyHealthBar _healthBar;
        private int _currentHealth;

        public event Action TargetDestroyed;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
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
                TargetDestroyed?.Invoke();
                transform.gameObject.SetActive(false);
            }
        }
    }
}