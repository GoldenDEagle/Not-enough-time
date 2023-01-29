using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Characters.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        // parameters
        [SerializeField] private float _playerSpeed = 2.0f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _rotationSpeed = 4f;
        [SerializeField] private float _gravityValue = -9.81f;


        // references
        [SerializeField] private InputActionReference _interactionControl;
        private CharacterController _characterController;
        private Transform _cameraMainTransform;
        private Animator _animator;

        // animator keys
        private static readonly int IsGroundedKey = Animator.StringToHash("is-grounded");
        private static readonly int IsRunningKey = Animator.StringToHash("is-running");
        private static readonly int JumpKey = Animator.StringToHash("jump");

        // internal variables
        private Vector2 _direction;
        private Vector3 _playerVelocity;
        private bool _isGrounded;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _cameraMainTransform = Camera.main.transform;
        }

        private void OnEnable()
        {
            _interactionControl.action.Enable();
        }

        void FixedUpdate()
        {
            // ground check
            _isGrounded = _characterController.isGrounded;
            _animator.SetBool(IsGroundedKey, _isGrounded);
            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            MovePlayer();

            // gravity affection
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

            RotatePlayer();
        }

        private void MovePlayer()
        {
            Vector3 move = new Vector3(_direction.x, 0, _direction.y);
            move = _cameraMainTransform.forward * move.z + _cameraMainTransform.right * move.x;
            move.y = 0f;

            _characterController.Move(move * Time.deltaTime * _playerSpeed);

            _animator.SetBool(IsRunningKey, move != Vector3.zero);
        }

        // rotation depending on input & camera direction
        private void RotatePlayer()
        {
            if (_direction != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg + _cameraMainTransform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
            }
        }

        // direction from input
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        // jump from input
        public void Jump()
        {
            if (_isGrounded)
            {
                _animator.SetTrigger(JumpKey);
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            }
        }

        private void OnDisable()
        {
            _interactionControl.action.Disable();
        }
    }
}