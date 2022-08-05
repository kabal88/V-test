﻿using System;
using Interfaces;
using UnityEngine;

namespace Controllers.UnitStates
{
    public class MovingToTargetState : UnitStateBase
    {
        public MovingToTargetState(IUnitContext unit) : base(unit)
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
                case SearchingForTargetState searchingForTargetState:
                    Unit.SetState(searchingForTargetState);
                    break;
                default:
                    break;
            }
        }

        public override void StartState()
        {
            Unit.View.SetTarget(Unit.Model.Target.Position);
        }

        public override void UpdateLocal(float deltaTime)
        {
            Debug.DrawLine(Unit.Model.Position,Unit.Model.Target.Position,Color.gray,Unit.Model.AttackDistance);
            
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
                Unit.HandleState(Unit.FightingState);
                return;
            }
            
            Unit.View.SetTarget(Unit.Model.Target.Position);
            
            //Debug.DrawLine(Unit.Model.Position, Unit.Model.Target.Position);
        }
    }
}