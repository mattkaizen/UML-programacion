using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(AudioSource))]
    public class DoorSound : MonoBehaviour
    {
        [SerializeField] AudioClip _doorOpenClip;
        [SerializeField] AudioClip _doorCloseClip;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayOpenSound()
        {
            PlayOneShotClip(_doorOpenClip);
        }
        
        public void PlayCloseSound()
        {
            PlayOneShotClip(_doorCloseClip);

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