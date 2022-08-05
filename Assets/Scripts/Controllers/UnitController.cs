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

        private UnitModel _model;
        private UnitView _view;

        private UnitStateBase _currentState;

        public bool IsAlive => _model.IsAlive;
        public int Side => _model.Side;
        public Vector3 Position => _model.Position;
        public IdleState IdleState { get; private set; }
        public DeadState DeadState { get; private set; }
        public FightingState FightingState { get; private set; }
        public MovingToTargetState MovingToTargetState { get; private set; }
        public SearchingForTargetState SearchingForTargetState { get; private set; }
        public UnitModel Model => _model;
        public UnitView View => _view;

        public UnitController(UnitModel model, GameObject root, GameObject shape, SpawnData spawnData, Material color,
            float size)
        {
            _model = model;
            var obj = GameObject.Instantiate(root, spawnData.Position, spawnData.Rotation).GetComponent<UnitView>();
            GameObject.Instantiate(shape, obj.transform);
            _view = obj.GetComponent<UnitView>();
            _view.Init(color, size, model.Speed);

            IdleState = new IdleState(this);
            DeadState = new DeadState(this);
            FightingState = new FightingState(this);
            MovingToTargetState = new MovingToTargetState(this);
            SearchingForTargetState = new SearchingForTargetState(this);

            _model.SetPosition(_view.Position);
            SetState(IdleState);

            ServiceLocator.Get<UpdateLocalService>().RegisterObject(this);
        }

        public void SetActive(bool isOn)
        {
            _model.SetIsActive(isOn);
            HandleState(isOn ? SearchingForTargetState : IdleState);
        }

        public void UpdateLocal(float deltaTime)
        {
            if (_model.IsActive)
            {
                _model.SetPosition(_view.Position);
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
            Dead?.Invoke(_model.Side);
        }

        public void TakeDamage(float damage)
        {
            _model.SetCurrentHealth(_model.CurrentHealth - damage);
            _view.PlayHitedAnimation();
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
            
            _model.Dispose();
            _model = null;
            
            GameObject.Destroy(_view.gameObject);
            _view = null;
        }
    }
}