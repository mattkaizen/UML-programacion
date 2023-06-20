using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(CircuitBreakerAnimation), typeof(CircuitBreakerSound))]
    public class CircuitBreakerObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive
        {
            get => isActive;
        }

        [SerializeField] private bool isActive;

        [SerializeField] PowerSource powerSource;

        private ISwitchable _switchable;
        private CircuitBreakerAnimation _circuitBreakerAnimation;
        private CircuitBreakerSound _circuitBreakerSound;

        private void Awake()
        {
            _switchable = FindObjectOfType<Electricity>();
            _circuitBreakerAnimation = GetComponent<CircuitBreakerAnimation>();
            _circuitBreakerSound = GetComponent<CircuitBreakerSound>();

            _switchable = powerSource.GetComponent<ISwitchable>();
        }

        public void Activate()
        {
            _circuitBreakerAnimation.PlayTurnOnAnimation();
            isActive = true;

            if (powerSource.IsFunctional())
            {
                _circuitBreakerSound.PlayTurnOnSound();
                _switchable.Activate();
            }
        }

        public void Deactivate()
        {
            _circuitBreakerAnimation.PlayTurnOffAnimation();
            _switchable.Deactivate();
            isActive = false;

            if (powerSource.IsFunctional())
            {
                _circuitBreakerSound.PlayTurnOffSound();
            }
        }
    }
}