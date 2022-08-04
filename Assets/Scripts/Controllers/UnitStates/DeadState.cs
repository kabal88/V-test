using Interfaces;

namespace Controllers.UnitStates
{
    public class DeadState : UnitStateBase
    {
        public DeadState(IUnitContext unit) : base(unit)
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