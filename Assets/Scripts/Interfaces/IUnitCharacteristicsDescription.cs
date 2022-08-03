using Data;

namespace Interfaces
{
    public interface IUnitCharacteristicsDescription : IDescription
    {
        HealthData HealthData { get; }
        AttackData AttackData { get; }
        float Speed { get; }
    }
}