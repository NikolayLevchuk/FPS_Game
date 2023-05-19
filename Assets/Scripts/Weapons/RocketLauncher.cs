using UnityEngine;

namespace Assets.Scripts
{
    public class RocketLauncher : MonoBehaviour, IWeaponable
    {
        [SerializeField] private int _rocketsLeft = 1;
        [SerializeField] private int _rocketAmount = 1;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private RocketForLauncher _rocket;
        [SerializeField] private GameObject _shotEffect;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shotSound;

        [Header("Animation")]
        [SerializeField] private Animator _animator;

        public int CurrentRounds => _rocketsLeft;
        public int RoundsAmount => _rocketAmount;
        public int AllRounrs => _rocketsLeft;

        private void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _rocketsLeft > 0)
            {
                _animator.Play("Shot");
                _rocketsLeft--;
                _audioSource.PlayOneShot(_shotSound);
                RocketForLauncher rocket = Instantiate(_rocket, _shotPoint.position, _shotPoint.rotation);
                GameObject shotEffect = Instantiate(_shotEffect, _shotPoint.position, _shotPoint.rotation);
            }
        }
    }
}