using UnityEngine;

namespace Assets.Scripts.Traps
{
    public class FogTrap : MonoBehaviour
    {
        private Collider _triggerCollider;
        private ParticleSystem _particles;
        private AudioSource _source;

        private void Awake()
        {
            _triggerCollider = GetComponent<Collider>();
            _particles = GetComponentInChildren<ParticleSystem>();
            _source = GetComponent<AudioSource>();
        }

        public void EnableTrap()
        {
            _particles.Play();
            _source.Play();
            _triggerCollider.enabled = true;
        }

        public void DisableTrap()
        {
            _particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            _source.Stop();
            _triggerCollider.enabled = false;
        }
    }
}