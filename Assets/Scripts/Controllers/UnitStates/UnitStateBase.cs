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

        public abstract void HandleState(UnitStateBase newState);
        public abstract void StartState();
        public abstract void UpdateLocal(float deltaTime);
        
        protected bool IsTargetReached()
        {
            var sqrDistance = (Unit.Model.Target.Position - Unit.Model.Position).sqrMagnitude;
            var sqrAttackDistance = Unit.Model.AttackDistance * Unit.Model.AttackDistance;

            return sqrDistance < sqrAttackDistance;
        }

        public virtual void Dispose()
        {
            Unit = null;
        }
    }
}