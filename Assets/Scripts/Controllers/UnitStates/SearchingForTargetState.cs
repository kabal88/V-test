using System;
using Interfaces;

namespace Controllers.UnitStates
{
    public class SearchingForTargetState : UnitStateBase
    {
        public SearchingForTargetState(IUnitContext unit) : base(unit)
        {
        }

        public override void SetState(UnitStateBase newState)
        {
            switch (newState)
            {
                case DeadState deadState:
                    break;
                case FightingState fightingState:
                    break;
                case IdleState idleState:
                    break;
                case MovingToTargetState movingToTargetState:
                    break;
                case SearchingForTargetState searchingForTargetState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState));
            }
        }

        public override void UpdateLocal(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}