using Interfaces;
using UnityEngine;

namespace Items
{
    public class CircuitBreaker : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        private ISwitchable _switchable; 
        private bool _isActive;

        private void Awake()
        {
            _switchable = FindObjectOfType<Electricity>();
        }

        public void Activate()
        {
            _switchable.Activate();
        }

        public void Deactivate()
        {
            _switchable.Deactivate();
        }
    }
}