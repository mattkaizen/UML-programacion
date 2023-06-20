using Interfaces;

namespace Items
{
    public class Electricity : PowerSource, ISwitchable
    {
        public bool IsActive
        {
            get => _isActive;
        }

        private bool _isActive;
        private PowerState _currentState;

        private void Awake()
        {
            _currentState = PowerState.Faulty;
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
            _isActive = true;
            _currentState = PowerState.On;
        }

        public void Deactivate()
        {
            _isActive = false;
            _currentState = PowerState.Off;
        }
    }
}