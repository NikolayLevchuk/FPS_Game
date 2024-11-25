using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private bool _canMove;

        [Header("Moving")]
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravity;

        [Header("Rotation")]
        [SerializeField] private Camera _cameraMain;
        [SerializeField] private float _sensetivity;
        [SerializeField] private float _rotationXLimit;

        [Header("Animation")]
        [SerializeField] private Animator _animator;

        private CharacterController _characterController;
        private Vector3 _moveDirection = Vector3.zero;
        private float _rotationX;

        private void OnEnable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnDisable()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        void Update()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            float curSpeedZ = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedX = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Horizontal") : 0;

            float movementDirectionY = _moveDirection.y;

            Vector3 move = new Vector3(curSpeedX, movementDirectionY, curSpeedZ);

            _moveDirection = (forward * curSpeedZ) + (right * curSpeedX);


            if (Input.GetKey(KeyCode.Space) && _canMove && _characterController.isGrounded)
            {
                _moveDirection.y = _jumpForce;
            }
            else
            {
                _moveDirection.y = movementDirectionY;
            }

            if (!_characterController.isGrounded)
            {
                _moveDirection.y -= _gravity * Time.deltaTime;
            }

            _characterController.Move(_moveDirection * Time.deltaTime);

            if (_canMove)
            {
                _rotationX += Input.GetAxis("Mouse Y") * _sensetivity;
                _rotationX = Mathf.Clamp(_rotationX, -_rotationXLimit, _rotationXLimit);
                _cameraMain.transform.localRotation = Quaternion.Euler(-_rotationX, 0, 0);

                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _sensetivity, 0);
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                _animator.SetInteger("State", 1);
            }
            else
            {
                _animator.SetInteger("State", 0);
            }
        }
    }

}