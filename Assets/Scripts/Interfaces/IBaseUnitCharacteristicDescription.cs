using UnityEngine;

namespace Interfaces
{
    public interface IBaseUnitCharacteristicDescription : IUnitCharacteristicsDescription
    {
        GameObject RootPrefab { get; }
    }
}