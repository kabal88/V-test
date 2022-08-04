using Controllers.UnitStates;

namespace Interfaces
{
    public interface IUnitContext
    {
        IdleState IdleState { get; }
        DeadState DeadState { get; }
        FightingState FightingState { get; }
        MovingToTargetState MovingToTargetState { get; }
        SearchingForTargetState SearchingForTargetState { get; }
        
        void SetState(UnitStateBase newState);
    }
}