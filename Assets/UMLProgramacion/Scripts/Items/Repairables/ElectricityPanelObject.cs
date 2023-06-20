using System.Collections;
using Data;
using Interfaces;
using Items;
using UnityEngine;

namespace Repairables
{
    [RequireComponent(typeof(ElectricityPanelSound), typeof(ElectricityPanelAnimation))]
    public class ElectricityPanelObject : MonoBehaviour, IRepairable
    {
        public ItemData RepairsWithItem => repairsWithItem;
        public bool IsRepaired => _isRepaired;

        [SerializeField] private ItemData repairsWithItem;
        [SerializeField] private PowerSource powerSource;

        private bool _isRepaired;

        private ElectricityPanelSound _electricityPanelSound;
        private ElectricityPanelAnimation _electricityPanelAnimation;

        private void Awake()
        {
            _electricityPanelSound = GetComponent<ElectricityPanelSound>();
            _electricityPanelAnimation = GetComponent<ElectricityPanelAnimation>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(5.0f);
            PowerOutrage();
        }

        public void TryRepair(ItemData item)
        {
            if (_isRepaired)
            {
                return;
            }

            var isNeededItem = item == repairsWithItem;

            if (isNeededItem)
            {
                Repair();
            }
        }

        private void Repair()
        {
            _isRepaired = true;
            _electricityPanelAnimation.PlayCloseAnimation();

            if (powerSource.CurrentState == PowerState.Faulty)
            {
                _electricityPanelSound.PlayClosePanelSound();
                _electricityPanelSound.PlayTurnOnSound();
                powerSource.CurrentState = PowerState.On;
            }
            else if (powerSource.CurrentState == PowerState.FaultyOff)
            {
                _electricityPanelSound.PlayClosePanelSound();
                powerSource.CurrentState = PowerState.Off;
            }
        }

        private void PowerOutrage()
        {
            if (powerSource.CurrentState == PowerState.On)
            {
                powerSource.CurrentState = PowerState.Faulty;
            }
            else if (powerSource.CurrentState == PowerState.Off)
            {
                powerSource.CurrentState = PowerState.FaultyOff;
            }

            _electricityPanelSound.PlayTurnOffSound();
        }
    }
}