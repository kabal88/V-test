using Data;

namespace Interfaces
{
    public interface ISpawnPoint
    {
        bool IsEmpty { get; }
        int Side { get; }
        SpawnData Data { get; }

        void SetIsEmpty(bool value);
    }
}