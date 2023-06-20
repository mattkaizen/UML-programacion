using Data;
using Interfaces;
using UnityEngine;

namespace Repairables
{
    public class ElectricityPanel : MonoBehaviour, IRepairable
    {
        public bool IsRepaired { get => _isRepaired; }
        public ItemData Data { get => _itemData; }

        private bool _isRepaired;
        private ItemData _itemData;

        public void Repair()
        {
            _isRepaired = true;
        }
    }
}