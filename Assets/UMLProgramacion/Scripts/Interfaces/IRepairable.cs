using Data;

namespace Interfaces
{
    public interface IRepairable
    {
        ItemData RepairsWithItem { get; }

        bool IsRepaired { get; }
        void TryRepair(ItemData item);
    }
}