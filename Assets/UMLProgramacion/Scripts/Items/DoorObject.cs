using Interfaces;
using UnityEngine;

namespace Items
{
    public class DoorObject : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => _isActive; }

        private bool _isActive;
        
        public void Activate()
        {
            Debug.Log("Activate");
            _isActive = true;
        }

        public void Deactivate()
        {
            Debug.Log("Deactivate");
            _isActive = false;
        }
    }
}