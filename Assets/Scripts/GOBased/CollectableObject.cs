using Assets.Scripts.InteractionSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GOBased
{
    public class CollectableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _interactionPrompt;
        [SerializeField] private UnityEvent _onCollected;
        public string InteractionPrompt => _interactionPrompt;

        public bool Interact()
        {
            _onCollected?.Invoke();
            return true;
        }
    }
}