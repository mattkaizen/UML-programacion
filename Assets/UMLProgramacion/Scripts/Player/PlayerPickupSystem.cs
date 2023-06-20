using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInventory))]
    public class PlayerPickupSystem : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] private float rayDistance;

        private PlayerInput _playerInput;
        private PlayerInventory _playerInventory;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerInventory = GetComponent<PlayerInventory>();
            _playerInput.PlayerControls.Interact.performed += OnInteractButtonPressed;
        }

        private void OnDrawGizmos()
        {
            Vector3 spawnPosition = camera.position;
            Debug.DrawRay(spawnPosition, camera.forward * rayDistance, Color.green, 0.5f);
        }
        
        private void OnInteractButtonPressed(InputAction.CallbackContext context)
        {
            TryPickup();
        }
        public void Pickup(IPickable item)
        {
            _playerInventory.AddItem(item.Data);
            item.Pickup();
        }

        private void TryPickup()
        {
            Vector3 spawnPosition = camera.position;
            if (Physics.Raycast(spawnPosition, camera.forward, out var hitInfo,
                    rayDistance))
            {
                if (hitInfo.collider.TryGetComponent<IPickable>(out var item))
                {
                    Pickup(item);
                }
            }
        }
    }
}