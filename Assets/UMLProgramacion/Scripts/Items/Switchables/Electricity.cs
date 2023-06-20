using Interfaces;
using UnityEngine;

namespace Items
{
    public class Electricity : PowerSource, ISwitchable
    {
        public bool IsActive => isActive;

        public override PowerState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        [SerializeField] private bool isActive;
        [SerializeField] private PowerState _currentState;

        private void Awake()
        {
            _currentState = PowerState.On;
        }


        public override bool HasEnergy()
        {
            if (_currentState == PowerState.On)
                return true;

            return false;
        }

        public override bool IsFunctional()
        {
            if (_currentState == PowerState.Faulty || _currentState == PowerState.FaultyOff )
            {
                return false;
            }
            return true;
        }

        public void Activate()
        {
            if (IsFunctional())
            {
                isActive = true;
                _currentState = PowerState.On;
            }
        }

        public void Deactivate()
        {
            if (IsFunctional())
            {
                isActive = false;
                _currentState = PowerState.Off;
            }
            else
            {
                _currentState = PowerState.FaultyOff;
            }
        }
    }
}