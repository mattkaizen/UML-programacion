using Data;
using Interfaces;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(RadioAnimation), typeof(RadioSound))]
    public class RadioObject : MonoBehaviour, ISwitchable
    {
        public ItemData ItemData => itemData;

        [SerializeField] private ItemData itemData;

        private RadioAnimation _animation;
        private RadioSound _sound;
        public bool IsActive { get; }

        private void Awake()
        {
            _animation = GetComponent<RadioAnimation>();
        }

        public void Activate()
        {
            _animation.PlayOnAnimation();
            _sound.PlaySound();
        }

        public void Deactivate()
        {
            _animation.StopOnAnimation();
            _sound.StopSound();

        }
    }
}