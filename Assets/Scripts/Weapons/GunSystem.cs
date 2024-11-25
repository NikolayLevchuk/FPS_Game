using UnityEngine;
using System;
using Assets.Scripts.Weapons;

namespace Assets.Scripts
{
    public class GunSystem : MonoBehaviour, IReloadable
    {
        [Header("Gun stats")]
        [SerializeField] private int _damage;
        [SerializeField] private float _timeBetweenShooting, _range, _reloadTime;
        [SerializeField] private int _magazineSize, _bulletsPerTap;
        [SerializeField] private int _magazineCount;
        [SerializeField] private bool _allowButtonHold;
        [SerializeField] private AudioClip[] _shotClips;
        [SerializeField] private AudioClip _emptyGunShot;
        [SerializeField] private AudioClip _reloadingSound;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _shotEffect;

        private int _bulletsLeft, _bulletsShot;

        private bool _shooting, _readyToShot, _reloading;

        [SerializeField] private Transform _attackPoint; 
        [SerializeField] private RaycastHit _rayHit;
        private Camera _camera;

        [Header("Animation")]
        private Animator _animator;

        public event Action Shot;
        public event Action Reloaded;

        public int CurrentRounds => _bulletsLeft;
        public int RoundsAmount => _magazineSize;
        public int AllRounds => (_magazineCount * _magazineSize);

        public Animator Animator
        {
            get => _animator;
            set
            {
                _animator = value;
            }
        }
        public int MagazineCount
        {
            get => _magazineCount;
            set
            {
                _magazineCount = value;
            }
        }

        private void Awake()
        {
            _animator = GetComponentInParent<Animator>();
            _bulletsLeft = _magazineSize;
            _readyToShot = true;
        }

        private void Start()
        {
            _animator = GetComponentInParent<Animator>();
            _camera = Camera.main;
        }

        private void Update()
        {
            CheckInput();         
        }

        private void CheckInput()
        {
            if (_allowButtonHold && _bulletsLeft > 0) _shooting = Input.GetKey(KeyCode.Mouse0);
            else _shooting = Input.GetKeyDown(KeyCode.Mouse0);

            if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < _magazineSize && !_reloading && _magazineCount > 0)
                Reload();

            if (_readyToShot && _shooting && !_reloading && _bulletsLeft > 0)
                Shoot();

            if ((_allowButtonHold && _shooting && _bulletsLeft <= 0) || _shooting && _bulletsLeft <= 0)
                _audioSource.PlayOneShot(_emptyGunShot);
        }

        protected virtual void Shoot()
        {
            _readyToShot = false;
            _animator.Play("Shot");
            _audioSource.PlayOneShot(_shotClips[UnityEngine.Random.Range(0, _shotClips.Length - 1)]);
            GameObject shotEffect = Instantiate(_shotEffect, _attackPoint.position, _attackPoint.rotation);
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _rayHit, _range))
            {
                IDamageble damagable = _rayHit.collider.GetComponent<IDamageble>();
                damagable?.ApplyDamage(_damage);
            }

            _bulletsLeft--;
            Shot?.Invoke();
            Invoke(nameof(ResetShot), _timeBetweenShooting);
        }

        private void ResetShot()
        {
            _readyToShot = true;
        }

        private void Reload()
        {
            _animator.Play("Reload");
            _reloading = true;
            _magazineCount--;
            Reloaded?.Invoke();
            _audioSource.PlayOneShot(_reloadingSound);
            Invoke(nameof(RealoadingFinished), _reloadTime);
        }

        private void RealoadingFinished()
        {
            _bulletsLeft = _magazineSize;
            _reloading = false;
        }
    }
}