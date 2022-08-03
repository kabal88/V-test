using UnityEngine;

namespace Interfaces
{
    public interface IColorCharacteristicDescription : IUnitCharacteristicsDescription
    {
        Color Color { get; }
    }
}