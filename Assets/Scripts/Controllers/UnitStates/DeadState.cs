﻿using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UnitStates
{
    public class DeadState : UnitStateBase
    {
        public DeadState(IUnitContext unit) : base(unit)
        {
        }

        public override void HandleState(UnitStateBase newState)
        {
        }

        public override void StartState()
        {
            Unit.View.PlayDeadAnimation();
            Unit.OnDead();
        }

        public override void UpdateLocal(float deltaTime)
        {
            
        }
    }
}