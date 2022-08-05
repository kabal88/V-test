using UnityEngine;

namespace Interfaces
{
    public interface ITarget: IDamagable
    {
        bool IsAlive { get; }
        int Side { get; }
        Vector3 Position { get; }
    }
}