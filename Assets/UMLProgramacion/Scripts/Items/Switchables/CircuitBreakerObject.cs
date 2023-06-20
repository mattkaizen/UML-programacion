using Interfaces;
using UnityEngine;

namespace Items
{
    
    [RequireComponent(typeof(CircuitBreakerAnimation), typeof(CircuitBreakerSound))]
    public class CircuitBreakerObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => isActive; }
        [SerializeField] private bool isActive;

        private ISwitchable _switchable; 
        private CircuitBreakerAnimation _circuitBreakerAnimation; 
        private CircuitBreakerSound _circuitBreakerSound; 

        private void Awake()
        {
            _switchable = FindObjectOfType<Electricity>();
            _circuitBreakerAnimation = GetComponent<CircuitBreakerAnimation>();
            _circuitBreakerSound = GetComponent<CircuitBreakerSound>();
        }

        public void Activate()
        {
            _circuitBreakerAnimation.PlayTurnOnAnimation();
            _circuitBreakerSound.PlayTurnOnSound();
            _switchable.Activate();
            isActive = true;
        }

        public void Deactivate()
        {
            _circuitBreakerAnimation.PlayTurnOffAnimation();
            _circuitBreakerSound.PlayTurnOffSound();
            _switchable.Deactivate();
            isActive = false;
        }
    }
}