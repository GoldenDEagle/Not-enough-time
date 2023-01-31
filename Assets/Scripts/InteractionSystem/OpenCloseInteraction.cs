using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.InteractionSystem
{
    public class OpenCloseInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isOpened;

        [Header("Animator Keys")]
        [SerializeField] private string _openAnimationKey = "Opening";
        [SerializeField] private string _closeAnimationKey = "Closing";

        [SerializeField] private UnityEvent _onDoorOpened;

        private string _interactionPrompt;

        public string InteractionPrompt => _interactionPrompt;

        private const string _openPrompt = "Open";
        private const string _closePrompt = "Close";

        void Start()
        {
            gameObject.layer = 6;
            _isOpened = false;
            _interactionPrompt = !_isOpened ? _openPrompt : _closePrompt;
        }

        public bool Interact()
        {
                if (_isOpened == false)
                {
                    StartCoroutine(OpeningRoutine());
                    _interactionPrompt = _closePrompt;
                    return true;
                }
                else if (_isOpened == true)
                {
                    StartCoroutine(ClosingRoutine());
                    _interactionPrompt = _openPrompt;
                    return true;
                }

                return false;
        }

        IEnumerator OpeningRoutine()
        {
            _animator.Play(_openAnimationKey);
            _isOpened = true;
            yield return new WaitForSeconds(.5f);
            _onDoorOpened?.Invoke();
        }

        IEnumerator ClosingRoutine()
        {
            _animator.Play(_closeAnimationKey);
            _isOpened = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}