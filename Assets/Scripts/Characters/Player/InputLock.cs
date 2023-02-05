using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Characters.Player
{
    public class InputLock : MonoBehaviour
    {
        private PlayerInput _input;

        private void Start()
        {
            _input = FindObjectOfType<PlayerInput>();
        }

        public void SetInput(bool isEnabled)
        {
            _input.enabled = isEnabled;
        }
    }
}