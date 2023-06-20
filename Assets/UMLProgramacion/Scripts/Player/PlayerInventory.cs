using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int maxSlots = 5;

        public Dictionary<ItemData, int> Items
        {
            get => _itemsInformacion;
        }
        
        private Dictionary<ItemData, int> _itemsInformacion = new Dictionary<ItemData, int>();


        public void AddItem(ItemData item)
        {
            if (item == null)
                return;

            if (_itemsInformacion.ContainsKey(item))
            {
                _itemsInformacion[item] += 1;
            }
            else
            {
                _itemsInformacion.Add(item, 1);
            }
        }
        
        public void TryRemoveFirstItem()
        {
            if (HasItems())
            {
                var firstValuePair = _itemsInformacion.FirstOrDefault();

                ItemData firstItem = firstValuePair.Key;
                
                if (firstValuePair.Value > 1)
                {
                    _itemsInformacion[firstItem] -= 1;
                    TryResetInventory();
                }
                else
                {
                    _itemsInformacion.Remove(firstItem);
                    TryResetInventory();
                }
            }
        }

        public bool GetItem(ItemData item)
        {
            if (_itemsInformacion.ContainsKey(item))
            {
                return true;
            }

            return false;
        }

        public bool HasAvailableSlot()
        {
            int itemsCount = _itemsInformacion.Values.Sum();

            if (itemsCount < maxSlots)
            {
                return true;
            }

            Debug.Log($"Amount of Items {itemsCount}");
            return false;
        }
        
        private bool HasItems()
        {
            if (_itemsInformacion.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void TryResetInventory()
        {
            if (_itemsInformacion.Count == 0)
            {
                _itemsInformacion = new Dictionary<ItemData, int>();
            }
        }
    }

}