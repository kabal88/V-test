using Interfaces;

namespace Controllers.UnitStates
{
    public class FightingState : UnitStateBase
    {
        private float _currentCooldown;

        public FightingState(IUnitContext unit) : base(unit)
        {
        }

        public override void HandleState(UnitStateBase newState)
        {
            switch (newState)
            {
                case DeadState deadState:
                    Unit.SetState(deadState);
                    break;
                case IdleState idleState:
                    Unit.SetState(idleState);
                    break;
                case MovingToTargetState movingToTargetState:
                    Unit.SetState(movingToTargetState);
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
            _currentCooldown = 0;
        }

        public override void UpdateLocal(float deltaTime)
        {
            if (!Unit.Model.IsAlive)
            {
                Unit.HandleState(Unit.DeadState);
                return;
            }

            if (!Unit.Model.Target.IsAlive)
            {
                Unit.HandleState(Unit.SearchingForTargetState);
                return;
            }

            if (IsTargetReached())
            {
                Unit.HandleState(Unit.MovingToTargetState);
                return;
            }

            _currentCooldown += deltaTime;
            if (Unit.Model.TimeBetweenAttack < _currentCooldown)
            {
                Unit.Model.Target.TakeDamage(Unit.Model.Attack);
                _currentCooldown = 0;
            }
        }
    }
}