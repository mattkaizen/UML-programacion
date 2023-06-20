using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(AudioSource))]
    public class LightSwitchSound : MonoBehaviour
    {
        [SerializeField] AudioClip _turnOnClip;
        [SerializeField] AudioClip _turnOffClip;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayTurnOnSound()
        {
            PlayOneShotClip(_turnOnClip);
        }
        
        public void PlayTurnOffSound()
        {
            PlayOneShotClip(_turnOffClip);

        }
        private void PlayOneShotClip(AudioClip clip)
        {
            if (_audioSource != null && clip != null)
            {
                _audioSource.PlayOneShot(clip);
            }
        }
    }
}