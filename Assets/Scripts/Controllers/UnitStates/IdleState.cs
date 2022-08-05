using Interfaces;

namespace Controllers.UnitStates
{
    public class IdleState : UnitStateBase
    {
        public IdleState(IUnitContext unit) : base(unit)
        {
        }

        public override void HandleState(UnitStateBase newState)
        {
            switch (newState)
            {
                case DeadState deadState:
                    Unit.SetState(deadState);
                    break;
                case SearchingForTargetState searchingForTargetState:
                    Unit.SetState(searchingForTargetState);
                    break;
                default:
                    break;
            }
            
            
        }

        public override void StartState()
        {
            
        }

        public override void UpdateLocal(float deltaTime)
        {
            if (!Unit.Model.IsAlive)
            {
                Unit.HandleState(Unit.DeadState);
                return;
            }
        }
    }
}