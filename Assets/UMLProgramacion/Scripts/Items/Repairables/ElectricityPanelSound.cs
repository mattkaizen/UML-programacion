using UnityEngine;

namespace Repairables
{
    public class ElectricityPanelSound : MonoBehaviour
    {
        [SerializeField] AudioClip turnOffClip;
        [SerializeField] AudioClip turnOnClip;
        [SerializeField] AudioClip closePanelClip;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlayClosePanelSound()
        {
            PlayOneShotClip(closePanelClip);
        }
        
        public void PlayTurnOnSound()
        {
            PlayOneShotClip(turnOnClip);
        }
        public void PlayTurnOffSound()
        {
            PlayOneShotClip(turnOffClip);
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