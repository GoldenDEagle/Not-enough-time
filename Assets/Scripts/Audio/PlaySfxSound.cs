using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class PlaySfxSound : MonoBehaviour
    {
        public const string SfxSourceTag = "SfxAudioSource";

        [SerializeField] private AudioClip _clip;

        private AudioSource _source;

        public void Play()
        {
            if (_source == null)
            {
                _source = GameObject.FindWithTag(SfxSourceTag).GetComponent<AudioSource>();
            }

            _source.PlayOneShot(_clip);
        }
    }
}
