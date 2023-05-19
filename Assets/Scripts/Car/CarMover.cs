using UnityEngine;

namespace Assets.Scripts
{
    public class CarMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private CarDestroyed _carDestroyed;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Animator[] _wheelsAnimator;

        private void Start()
        {
            _carDestroyed.TargetDestroyed += CarStop;
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.forward * _speed;
        }

        private void CarStop()
        {
            foreach (var wheel in _wheelsAnimator)
            {
                wheel.SetBool("CanMove", false);
            }
            _audioSource.enabled = false;
            _speed = 0;
        }
    }
}