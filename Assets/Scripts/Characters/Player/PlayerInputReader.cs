using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Characters.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _playerController.SetDirection(direction);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.Jump();
            }
        }

        public void OnPausePressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                WindowUtils.CreateWindow("Windows/PauseWindow");
            }
        }
    }
}
