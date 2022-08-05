using System;
using Interfaces;
using Services;
using UnityEngine;

namespace Controllers.UnitStates
{
    public class SearchingForTargetState : UnitStateBase
    {
        private TargetService _targetService;

        public SearchingForTargetState(IUnitContext unit) : base(unit)
        {
        }

        public override void HandleState(UnitStateBase newState)
        {
            switch (newState)
            {
                case DeadState deadState:
                    Unit.SetState(deadState);
                    break;
                case FightingState fightingState:
                    Unit.SetState(fightingState);
                    break;
                case IdleState idleState:
                    Unit.SetState(idleState);
                    break;
                case MovingToTargetState movingToTargetState:
                    Unit.SetState(movingToTargetState);
                    break;
                default:
                    break;
            }
        }

        public override void StartState()
        {
            _targetService = ServiceLocator.Get<TargetService>();
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
            
            SearchForTarget();
        }

        private void SearchForTarget()
        {
            var targets = _targetService.GetObjectsByPredicate(target => target.Side != Unit.Model.Side && target.IsAlive);

            if (targets == null)
            {
                Unit.HandleState(Unit.IdleState);
                return;
            }

            ITarget closestTarget = null;
            var closestSqrDistance = float.MaxValue;

            foreach (var target in targets)
            {
                var sqrDistance = (target.Position - Unit.Model.Position).sqrMagnitude;
                var sqrAttackDistance = Unit.Model.AttackDistance * Unit.Model.AttackDistance;
                if (sqrDistance < sqrAttackDistance)
                {
                    Unit.Model.SetTarget(target);
                    Unit.HandleState(Unit.FightingState);
                    return;
                }

                if (closestSqrDistance > sqrDistance)
                {
                    closestSqrDistance = sqrDistance;
                    closestTarget = target;
                }
            }

            if (closestTarget != null)
            {
                Unit.Model.SetTarget(closestTarget);
                Unit.HandleState(Unit.MovingToTargetState);
            }
        }
        
        private void DrawGizmo()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Unit.Model.Position, Unit.Model.AttackDistance);
        }
    }
}