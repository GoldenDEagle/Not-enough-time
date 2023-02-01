using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GOBased
{
    public class TransformBoundToObject : MonoBehaviour
    {
        [SerializeField] private Transform _boundObject;

        private Vector3 _lastPosition;

        private void Start ()
        {
            _lastPosition = _boundObject.position;
        }

        private void Update ()
        {
            if (_lastPosition == _boundObject.position)
                return;

            var delta = _boundObject.position - _lastPosition;
            _lastPosition = _boundObject.position;
            transform.Translate(delta);
        }
    }
}