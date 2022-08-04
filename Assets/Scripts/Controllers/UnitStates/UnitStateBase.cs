using System;
using Interfaces;

namespace Controllers.UnitStates
{
    public abstract class UnitStateBase : IUpdatable, IDisposable
    {
        protected IUnitContext Unit;

        public UnitStateBase(IUnitContext unit)
        {
            Unit = unit;
        }

        public abstract void SetState(UnitStateBase newState);
        public abstract void UpdateLocal(float deltaTime);

        public virtual void Dispose()
        {
            Unit = null;
        }
    }
}