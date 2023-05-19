using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _shotingClips;
        [SerializeField] private int _damage;
        [SerializeField] private float _shotDistance;
        [SerializeField] private float _shotTimer;

        [SerializeField] private int _bullets;
        [SerializeField] private int _bulletsMax;
        [SerializeField] private int _bulletsAll;

        public AudioClip[] ShotingClips => _shotingClips;
        public int Damage => _damage;
        public float ShotDistance => _shotDistance;
        public float ShotTimer => _shotTimer;
        public int BulletsMax => _bulletsMax;


        public int Bullets
        {
            get => _bullets;
            set
            {
                _bullets = value;
            }
        }

        public int BulletsAll
        {
            get => _bulletsAll;
            set
            {
                _bulletsAll = value;
            }
        }
    }
}