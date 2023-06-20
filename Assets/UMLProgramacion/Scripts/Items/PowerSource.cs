using UnityEngine;

namespace Items
{
    public abstract class PowerSource : MonoBehaviour
    {
        public abstract PowerState GetStatus();
        public abstract bool HasEnergy();
        public abstract bool IsFunctional();
    }
}