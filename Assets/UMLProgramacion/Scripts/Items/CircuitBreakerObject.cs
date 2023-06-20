using Interfaces;
using UnityEngine;

namespace Items
{
    
    [RequireComponent(typeof(CircuitBreakerAnimation), typeof(CircuitBreakerSound))]
    public class CircuitBreakerObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        private ISwitchable _switchable; 
        private CircuitBreakerAnimation _circuitBreakerAnimation; 
        private CircuitBreakerSound _circuitBreakerSound; 
        private bool _isActive;

        private void Awake()
        {
            _switchable = FindObjectOfType<Electricity>();
            _circuitBreakerAnimation = GetComponent<CircuitBreakerAnimation>();
            _circuitBreakerSound = GetComponent<CircuitBreakerSound>();
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