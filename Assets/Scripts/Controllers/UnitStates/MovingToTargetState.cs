using Interfaces;

namespace Controllers.UnitStates
{
    public class MovingToTargetState : UnitStateBase
    {
        public MovingToTargetState(IUnitContext unit) : base(unit)
        {
        }

        public override void SetState(UnitStateBase newState)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateLocal(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}