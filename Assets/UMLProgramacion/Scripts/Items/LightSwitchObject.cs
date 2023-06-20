using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(LightSwitchAnimation), typeof(LightSwitchSound))]
    public class LightSwitchObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        private bool _isActive;

        private LightSwitchAnimation _lightSwitchAnimation;
        private LightSwitchSound _lightSwitchSound;

        private void Awake()
        {
            _lightSwitchAnimation = GetComponent<LightSwitchAnimation>();
            _lightSwitchSound = GetComponent<LightSwitchSound>();
        }

        public void Activate()
        {
            _lightSwitchAnimation.PlayTurnOnAnimation();
            _lightSwitchSound.PlayTurnOnSound();
            _isActive = true;
            Debug.Log("Activate");
        }

        public void Deactivate()
        {
            _lightSwitchAnimation.PlayTurnOffAnimation();
            _lightSwitchSound.PlayTurnOffSound();
            _isActive = false;
            Debug.Log("Deactivate");
        }
    }
}