using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInventory))]
    public class PlayerRepairSystem : MonoBehaviour
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
            RayCastToRepairableItem();
        }
        public void TryRepair(IRepairable item)
        {
            if (!item.IsRepaired && _playerInventory.GetItem(item.Data))
            {
                item.Repair();
                _playerInventory.Items.Remove(item.Data);
            }
        }

        private void RayCastToRepairableItem()
        {
            Vector3 spawnPosition = camera.position;
            if (Physics.Raycast(spawnPosition, camera.forward, out var hitInfo,
                    rayDistance))
            {
                if (hitInfo.collider.TryGetComponent<IRepairable>(out var item))
                {
                    TryRepair(item);
                }
            }
        }
    }
}