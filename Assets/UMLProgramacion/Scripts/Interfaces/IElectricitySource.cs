using Items;

namespace Interfaces
{
    public interface IElectricitySource
    {
        PowerState GetStatus();
        bool IsFunctional();
    }
}