using UnityEngine;

namespace Interfaces
{
    public interface IColorCharacteristicDescription : IUnitCharacteristicsDescription
    {
        Material Color { get; }
    }
}