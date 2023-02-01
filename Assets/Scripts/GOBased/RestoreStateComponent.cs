using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GOBased
{
    public class RestoreStateComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        public string Id => _id;

        private void OnEnable()
        {
            _id = SceneManager.GetActiveScene().name + gameObject.name;
        }

        private void Start()
        {
            var isDestroyed = GameSession.Instance.RestoreDestructionState(Id);
            if (isDestroyed)
                Destroy(gameObject);
        }
    }
}