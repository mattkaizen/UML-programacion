﻿using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerSwitchSystem : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] private float rayDistance;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.PlayerControls.Interact.performed += OnInteractButtonPressed;
        }

        private void OnDrawGizmos()
        {
            Vector3 spawnPosition = camera.position;
            Debug.DrawRay(spawnPosition, camera.forward * rayDistance, Color.green, 0.5f);
        }
        
        private void OnInteractButtonPressed(InputAction.CallbackContext context)
        {
            RayCastToSwitchableObject();
        }
        public void Toggle(ISwitchable item)
        {
            if (item.IsActive)
            {
                item.Deactivate();
            }
            else
            {
                item.Activate();
            }
        }

        private void RayCastToSwitchableObject()
        {
            Vector3 spawnPosition = camera.position;
            if (Physics.Raycast(spawnPosition, camera.forward, out var hitInfo,
                    rayDistance))
            {
                if (hitInfo.collider.TryGetComponent<ISwitchable>(out var item))
                {
                    Toggle(item);
                }
            }
        }
    }
}