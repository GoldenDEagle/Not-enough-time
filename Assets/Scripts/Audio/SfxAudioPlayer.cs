using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class SfxAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _reduceTimeClip;
        [SerializeField] private AudioClip _addTimeClip;
        [SerializeField] private AudioClip _openClip;
        [SerializeField] private AudioClip _closeClip;
        [SerializeField] private AudioClip _outOfTimeClip;

        //public static PlaySfxSound Instance;

        //public void Play()
        //{
        //    _source.PlayOneShot(_clip);
        //}

        private AudioSource _source;
        private AudioClip _clip;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            GameEvents.Instance.OnSoundPlay += PlaySound;
        }

        private void PlaySound(SfxSound id)
        {
            switch (id)
            {
                case SfxSound.ReduceTime:
                    _clip = _reduceTimeClip;
                    break;
                case SfxSound.AddTime:
                    _clip = _addTimeClip;
                    break;
                case SfxSound.Open:
                    _clip = _openClip;
                    break;
                case SfxSound.Close:
                    _clip = _closeClip;
                    break;
                default:
                    throw new UnassignedReferenceException("No such clip!");
            }

            _source.PlayOneShot(_clip);
        }
    }
}
