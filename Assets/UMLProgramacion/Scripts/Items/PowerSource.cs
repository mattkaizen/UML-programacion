using UnityEngine;

namespace Items
{
    public abstract class PowerSource : MonoBehaviour
    {
        public abstract PowerState CurrentState { get; set; }
        public abstract bool HasEnergy();
        public abstract bool IsFunctional();
    }
}