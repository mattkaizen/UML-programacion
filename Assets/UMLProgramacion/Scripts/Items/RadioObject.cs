using System;
using System.Collections;
using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(RadioAnimation), typeof(RadioSound))]
    public class RadioObject : MonoBehaviour, ISwitchable
    {
        public ItemData ItemData => itemData;
        public bool IsActive { get => isActive; }

        [SerializeField] private ItemData itemData;
        [SerializeField] private PowerSource powerSource;
        [SerializeField] private bool isActive;

        private RadioAnimation _animation;
        private RadioSound _sound;
        private void Awake()
        {
            _animation = GetComponent<RadioAnimation>();
            _sound = GetComponent<RadioSound>();
        }

        private void Start()
        {
            StartCoroutine(CheckPowerSourceRoutine());
            Activate();
        }

        public void Activate()
        {
            _animation.PlayOnAnimation();
            _sound.PlaySound();
            isActive = true;
        }

        public void Deactivate()
        {
            _animation.StopOnAnimation();
            _sound.StopSound();
            isActive = false;
        }
        
        private IEnumerator CheckPowerSourceRoutine()
        {
            while (true)
            {
                yield return new WaitWhile(powerSource.HasEnergy);
                _animation.StopOnAnimation();
                _sound.StopSound();
                yield return new WaitUntil(powerSource.HasEnergy);
                if (isActive)
                    Activate();
            }
        }
    }
}