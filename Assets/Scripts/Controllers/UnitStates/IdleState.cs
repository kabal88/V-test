using Interfaces;

namespace Controllers.UnitStates
{
    public class IdleState : UnitStateBase
    {
        public IdleState(IUnitContext unit) : base(unit)
        {
        }

        public override void SetState(UnitStateBase newState)
        {
            switch (newState)
            {
                case DeadState deadState:
                    Unit.SetState(deadState);
                    Dispose();
                    break;
                case SearchingForTargetState searchingForTargetState:
                    Unit.SetState(searchingForTargetState);
                    Dispose();
                    break;
                default:
                    break;
            }
        }

        public override void UpdateLocal(float deltaTime)
        {
        }
    }
}