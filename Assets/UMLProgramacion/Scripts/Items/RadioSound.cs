using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(AudioSource))]
    public class RadioSound : MonoBehaviour
    {
        [SerializeField] AudioClip songClip;
        private AudioSource _audioSource;

        private bool _isPaused;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound()
        {
            PlayClip(songClip);
            UnPauseAudioSource();
        }

        public void StopSound()
        {
            PauseAudioSource();
        }

        private void PlayClip(AudioClip clip)
        {
            if (_audioSource == null)
                return;
            
            if (_audioSource.clip == null)
            {
                _audioSource.clip = clip;
            }
            _audioSource.Play();
        }

        private void PauseAudioSource()
        {
            if (_audioSource == null)
                return;

            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
                _isPaused = true;

            }
        }

        private void UnPauseAudioSource()
        {
            if (_isPaused)
            {
                _audioSource.UnPause();
                _isPaused = false;
            }
        }
    }
}