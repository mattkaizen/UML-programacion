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
            get => isActive;
        }

        [SerializeField] private bool isActive;
        [SerializeField] private Light lightBulb;

        [SerializeField] private PowerSource powerSource;
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
            isActive = true;
            _lightSwitchAnimation.PlayTurnOnAnimation();
            _lightSwitchSound.PlayTurnOnSound();

            if (powerSource != null && powerSource.HasEnergy())
                SetLight(true);
        }

        public void Deactivate()
        {
            isActive = false;
            _lightSwitchAnimation.PlayTurnOffAnimation();
            _lightSwitchSound.PlayTurnOffSound();

            if (powerSource != null && powerSource.HasEnergy())
                SetLight(false);
        }

        private void SetLight(bool state)
        {
            if (lightBulb != null)
                lightBulb.enabled = state;
        }

        private IEnumerator CheckPowerSourceRoutine()
        {
            while (true)
            {
                yield return new WaitWhile(powerSource.HasEnergy);
                SetLight(false);
                yield return new WaitUntil(powerSource.HasEnergy);
                if (isActive)
                    SetLight(true);
            }
        }
    }
}