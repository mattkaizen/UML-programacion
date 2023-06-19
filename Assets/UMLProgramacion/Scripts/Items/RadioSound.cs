using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(AudioSource))]
    public class RadioSound : MonoBehaviour
    {
        [SerializeField] AudioClip songClip;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlaySound()
        {
            PlayClip(songClip);
        }
        
        public void StopSound()
        {
            StopClip();
        }
        
        private void PlayClip(AudioClip clip)
        {
            if (_audioSource != null && clip != null)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
        
        private void StopClip()
        {
            if (_audioSource != null && _audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }
}