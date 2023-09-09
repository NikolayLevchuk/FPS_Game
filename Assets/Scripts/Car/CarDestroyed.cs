using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CarDestroyed : MonoBehaviour, IDamageble, IEnemieble
    {
        [SerializeField] private int _hp;
        [SerializeField] private GameObject _smokeEffect;
        [SerializeField] private bool _thisCarMustBeDestroyed;

        public event Action TargetDestroyed;

        public void ApplyDamage(int damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                _smokeEffect.SetActive(true);
                if (_thisCarMustBeDestroyed)
                {
                    TargetDestroyed?.Invoke();
                    _thisCarMustBeDestroyed = false;
                }
            }
        }
    }

}