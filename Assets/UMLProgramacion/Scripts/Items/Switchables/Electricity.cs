using Interfaces;
using UnityEngine;

namespace Items
{
    public class Electricity : PowerSource, ISwitchable
    {
        public bool IsActive
        {
            get => isActive;
        }

        [SerializeField] private bool isActive;
        private PowerState _currentState;

        private void Awake()
        {
            _currentState = PowerState.On;
        }


        public override PowerState GetStatus()
        {
            return _currentState;
        }

        public override bool HasEnergy()
        {
            if (_currentState == PowerState.On)
                return true;

            return false;
        }

        public override bool IsFunctional()
        {
            return _currentState != PowerState.Faulty;
        }

        public void Activate()
        {
            isActive = true;
            _currentState = PowerState.On;
        }

        public void Deactivate()
        {
            isActive = false;
            _currentState = PowerState.Off;
        }
    }
}