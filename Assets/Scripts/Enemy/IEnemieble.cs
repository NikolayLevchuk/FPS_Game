using System;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IEnemieble
    {
        public GameObject gameObject => gameObject;
        public event Action TargetDestroyed;
    }
}