using UnityEngine;

namespace Assets.Scripts.Traps
{
    public class FogTrap : MonoBehaviour
    {
        private Collider _triggerCollider;
        private ParticleSystem _particles;

        private void Awake()
        {
            _triggerCollider = GetComponent<Collider>();
            _particles = GetComponentInChildren<ParticleSystem>();
        }

        public void EnableTrap()
        {
            _particles.Play();
            _triggerCollider.enabled = true;
        }

        public void DisableTrap()
        {
            _particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            _triggerCollider.enabled = false;
        }
    }
}