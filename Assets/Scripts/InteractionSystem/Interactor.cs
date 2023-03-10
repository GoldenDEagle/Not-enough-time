using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.InteractionSystem
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private Transform _interactionPoint;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _interactableMask;
        [SerializeField] private InputActionReference _interactionControl;
        [SerializeField] private InteractionPromptUI _interactionPromptUI;

        private Collider[] _objectsInRange = new Collider[3];
        private int _objectsFound;
        private IInteractable _interactable;

        private void OnEnable()
        {
            _interactionControl.action.Enable();
        }

        private void Update()
        {
            // searches for objects on interactable layer in a sphere
            _objectsFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius,
                _objectsInRange, _interactableMask);

            if (_objectsFound > 0)
            {
                _interactable = _objectsInRange[0].GetComponent<IInteractable>();

                if (_interactable != null)
                {
                    // display prompt
                    _interactionPromptUI.ShowPrompt(_interactable.InteractionPrompt);

                    // interact
                    if (_interactionControl.action.triggered)
                    {
                        _interactable.Interact();
                    }
                }
            }
            else
            {
                if (_interactionPromptUI.gameObject.activeInHierarchy)
                    _interactionPromptUI.gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
        }

        private void OnDisable()
        {
            _interactionControl.action.Disable();
        }
    }
}