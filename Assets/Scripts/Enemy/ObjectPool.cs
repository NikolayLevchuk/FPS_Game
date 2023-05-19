using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool instance;

        [SerializeField] private EnemysProjectile _prefab;
        private readonly List<EnemysProjectile> _pooledObjects = new List<EnemysProjectile>();

        private void Awake()
        {
            if (instance == null) 
            { 
                instance = this;
            }
        }

        public EnemysProjectile GetBullet()
        {
            EnemysProjectile bullet;
            if (_pooledObjects.Count > 0)
            {
                bullet = _pooledObjects[0];
                _pooledObjects.Remove(bullet);
            }
            else
            {
                bullet = Instantiate(_prefab);
            }
            bullet.Destroyed += ReturnBullet;
            return bullet;
        }

        private void ReturnBullet(EnemysProjectile bullet) 
        {
            bullet.Destroyed -= ReturnBullet;
            _pooledObjects.Add(bullet);
        }
    }
}