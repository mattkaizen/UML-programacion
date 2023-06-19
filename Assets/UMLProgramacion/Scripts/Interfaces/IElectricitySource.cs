using Items;

namespace Interfaces
{
    public interface IElectricitySource
    {
        ElectricityState GetStatus();
        bool IsFunctional();
    }
}