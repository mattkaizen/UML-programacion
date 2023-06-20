using Data;

namespace Interfaces
{
    public interface IRepairable
    {
        
        ItemData Data { get; }
        bool IsRepaired { get; }
        void Repair();
    }
}