using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    public class BatteryObject : MonoBehaviour, IPickable
    {
        public ItemData Data => itemData;

        [SerializeField] private ItemData itemData;
        public void Pickup()
        {
            gameObject.SetActive(false);
        }

    }
}