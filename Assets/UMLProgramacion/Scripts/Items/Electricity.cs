using System;
using Interfaces;
using UnityEngine;

namespace Items
{
    public class Electricity : MonoBehaviour, IElectricitySource, ISwitchable
    {
        public bool IsActive
        {
            get => _isActive;
        }

        private bool _isActive;
        private ElectricityState _currentState;

        private void Awake()
        {
            _currentState = ElectricityState.Faulty;
        }

        public ElectricityState GetStatus()
        {
            return _currentState;
        }

        public bool IsFunctional()
        {
            return _currentState != ElectricityState.Faulty;
        }

        public void Activate()
        {
            _isActive = true;
            _currentState = ElectricityState.On;
        }

        public void Deactivate()
        {
            _isActive = false;
            _currentState = ElectricityState.Off;
        }
    }
}