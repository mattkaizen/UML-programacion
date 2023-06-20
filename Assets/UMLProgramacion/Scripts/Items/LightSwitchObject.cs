using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(LightSwitchAnimation), typeof(LightSwitchSound))]
    public class LightSwitchObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive
        {
            get => _isActive;
        }

        [SerializeField] private bool _isActive;
        [SerializeField] private Light lightBulb;

        [SerializeField] private PowerSource electricity;
        private LightSwitchAnimation _lightSwitchAnimation;
        private LightSwitchSound _lightSwitchSound;


        private void Awake()
        {
            _lightSwitchAnimation = GetComponent<LightSwitchAnimation>();
            _lightSwitchSound = GetComponent<LightSwitchSound>();
        }

        private void Start()
        {
            StartCoroutine(CheckPowerSourceRoutine());
        }

        public void Activate()
        {
            _isActive = true;
            _lightSwitchAnimation.PlayTurnOnAnimation();
            _lightSwitchSound.PlayTurnOnSound();
            SetLight(true);
        }

        public void Deactivate()
        {
            _isActive = false;
            _lightSwitchAnimation.PlayTurnOffAnimation();
            _lightSwitchSound.PlayTurnOffSound();
            SetLight(false);
        }

        private void SetLight(bool state)
        {
            if (lightBulb != null && electricity != null && electricity.HasEnergy())
                lightBulb.enabled = state;
        }

        private IEnumerator CheckPowerSourceRoutine()
        {
            while (true)
            {
                yield return new WaitWhile(electricity.HasEnergy);
                SetLight(false);
                yield return new WaitUntil(electricity.HasEnergy);
            }
        }
    }
}