using Interfaces;
using UnityEngine;

namespace Controllers.UnitStates
{
    public class FightingState : UnitStateBase
    {
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
            Unit.View.Callback = DrawGizmo; //todo: delete
        }

        public override void UpdateLocal(float deltaTime)
        {
            if (!Unit.Model.IsAlive)
            {
                Unit.HandleState(Unit.DeadState);
                return;
            }

            if (Unit.Model.TimeBetweenAttack >= Unit.Model.CurrentAttackCooldown)
                Unit.Model.SetCurrentAttackCooldown(Unit.Model.CurrentAttackCooldown + deltaTime);

            if (!Unit.Model.Target.IsAlive)
            {
                Unit.HandleState(Unit.SearchingForTargetState);
                return;
            }

            if (!IsTargetReached())
            {
                Unit.HandleState(Unit.MovingToTargetState);
                return;
            }

            if (Unit.Model.TimeBetweenAttack < Unit.Model.CurrentAttackCooldown)
            {
                Unit.View.PlayAttackAnimation();
                Unit.Model.Target.TakeDamage(Unit.Model.Attack);
                Unit.Model.SetCurrentAttackCooldown(0);
            }
        }

        private void DrawGizmo()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(Unit.Model.Position, Unit.Model.AttackDistance);
        }
    }
}