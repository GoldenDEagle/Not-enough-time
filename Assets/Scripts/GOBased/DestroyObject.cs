using UnityEngine;

namespace Assets.Scripts.GOBased
{
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField] private GameObject _targetToDestroy;

        public void DestroyTarget()
        {
            Destroy(_targetToDestroy);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
