using System;
using Controllers.UnitStates;
using Data;
using Interfaces;
using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class UnitController : ITarget, IUpdatable, IActivatable, IUnitContext, IDisposable
    {
        public event Action<int> Dead;

        private UnitStateBase _currentState;

        public bool IsAlive => Model.IsAlive;
        public int Side => Model.Side;
        public Vector3 Position => Model.Position;
        public IdleState IdleState { get; private set; }
        public DeadState DeadState { get; private set; }
        public FightingState FightingState { get; private set; }
        public MovingToTargetState MovingToTargetState { get; private set; }
        public SearchingForTargetState SearchingForTargetState { get; private set; }
        public UnitModel Model { get; private set; }
        public UnitView View { get; private set; }

        
        public UnitController(UnitModel model, GameObject root, GameObject shape, SpawnData spawnData, Material color,
            float size)
        {
            Model = model;
            var obj = GameObject.Instantiate(root, spawnData.Position, spawnData.Rotation).GetComponent<UnitView>();
            GameObject.Instantiate(shape, obj.transform);
            View = obj.GetComponent<UnitView>();
            View.Init(color, size, model.Speed);

            IdleState = new IdleState(this);
            DeadState = new DeadState(this);
            FightingState = new FightingState(this);
            MovingToTargetState = new MovingToTargetState(this);
            SearchingForTargetState = new SearchingForTargetState(this);

            Model.SetPosition(View.Position);
            SetState(IdleState);

            ServiceLocator.Get<UpdateLocalService>().RegisterObject(this);
        }

        public void SetActive(bool isOn)
        {
            Model.SetIsActive(isOn);
            HandleState(isOn ? SearchingForTargetState : IdleState);
        }

        public void UpdateLocal(float deltaTime)
        {
            if (Model.IsActive)
            {
                Model.SetPosition(View.Position);
                _currentState.UpdateLocal(deltaTime);
            }
        }

        public void SetState(UnitStateBase newState)
        {
            _currentState = newState;
            _currentState.StartState();
        }

        public void HandleState(UnitStateBase newState)
        {
            _currentState.HandleState(newState);
        }

        public void OnDead()
        {
            Dead?.Invoke(Model.Side);
        }

        public void TakeDamage(float damage)
        {
            Model.SetCurrentHealth(Model.CurrentHealth - damage);
            View.PlayReceiveHitAnimation();
        }

        public void Dispose()
        {
            ServiceLocator.Get<UpdateLocalService>().UnRegisterObject(this);

            IdleState.Dispose();
            IdleState = null;

            DeadState.Dispose();
            DeadState = null;

            FightingState.Dispose();
            FightingState = null;

            MovingToTargetState.Dispose();
            MovingToTargetState = null;

            SearchingForTargetState.Dispose();
            SearchingForTargetState = null;

            _currentState.Dispose();
            _currentState = null;
            
            Model.Dispose();
            Model = null;
            
            GameObject.Destroy(View.gameObject);
            View = null;
        }
    }
}