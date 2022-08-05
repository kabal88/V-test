using UnityEngine;

namespace Interfaces
{
    public interface IBaseUnitCharacteristicDescription : IUnitCharacteristicsDescription
    {
        float BaseTimeBetweenAttack { get; }
        GameObject RootPrefab { get; }
    }
}