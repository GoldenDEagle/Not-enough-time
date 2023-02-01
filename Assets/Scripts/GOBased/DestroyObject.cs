using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.GOBased
{
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField] private GameObject _targetToDestroy;

        private RestoreStateComponent _stateComponent;

        private void OnEnable()
        {
            if (TryGetComponent<RestoreStateComponent>(out RestoreStateComponent stateComponent))
                _stateComponent = stateComponent;
        }

        public void DestroyTarget()
        {
            Destroy(_targetToDestroy);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
            if (_stateComponent != null)
                GameSession.Instance.StoreDestructionState(_stateComponent.Id);
        }
    }
}
