using UnityEngine;

namespace Interfaces
{
    public interface IShapeCharacteristicDescription : IUnitCharacteristicsDescription
    {
        GameObject Prefab { get; }
    }
}