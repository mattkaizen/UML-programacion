using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(LightSwitchAnimation), typeof(LightSwitchSound))]
    public class LightSwitchObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        [SerializeField] private Light lightBulb; 

        private LightSwitchAnimation _lightSwitchAnimation;
        private LightSwitchSound _lightSwitchSound;
        private bool _isActive;


        private void Awake()
        {
            _lightSwitchAnimation = GetComponent<LightSwitchAnimation>();
            _lightSwitchSound = GetComponent<LightSwitchSound>();
        }

        public void Activate()
        {
            _lightSwitchAnimation.PlayTurnOnAnimation();
            _lightSwitchSound.PlayTurnOnSound();
            SetLight(true);
            _isActive = true;
        }

        public void Deactivate()
        {
            _lightSwitchAnimation.PlayTurnOffAnimation();
            _lightSwitchSound.PlayTurnOffSound();
            SetLight(false);
            _isActive = false;
        }

        private void SetLight(bool state)
        {
            if (lightBulb != null)
                lightBulb.enabled = state;
        }
    }
}