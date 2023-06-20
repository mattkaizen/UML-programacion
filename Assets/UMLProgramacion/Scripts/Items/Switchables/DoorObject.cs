using System;
using Interfaces;
using UnityEngine;

namespace Items
{
    
    [RequireComponent(typeof(DoorAnimation), typeof(DoorSound))]
    public class DoorObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        private DoorAnimation _doorAnimation;
        private DoorSound _doorSound;
        private bool _isActive;

        private void Awake()
        {
            _doorAnimation = GetComponent<DoorAnimation>();
            _doorSound = GetComponent<DoorSound>();
        }

        public void Activate()
        {
            _doorAnimation.PlayOpenDoorAnimation();
            _doorSound.PlayOpenSound();
            _isActive = true;
        }

        public void Deactivate()
        {
            _doorAnimation.PlayCloseDoorAnimation();
            _doorSound.PlayCloseSound();
            _isActive = false;
        }
    }
}