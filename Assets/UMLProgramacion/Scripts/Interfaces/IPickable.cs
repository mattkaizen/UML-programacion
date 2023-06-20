using Data;

namespace Interfaces
{
    public interface IPickable
    {
        ItemData Data { get; }
        void Pickup();
    }
}