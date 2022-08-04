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
        private UnitModel _model;
        private UnitView _view;

        private UnitStateBase _currentState;

        public int Side => _model.Side;
        public IdleState IdleState { get; }
        public DeadState DeadState { get; }
        public FightingState FightingState { get; }
        public MovingToTargetState MovingToTargetState { get; }
        public SearchingForTargetState SearchingForTargetState { get; }

        public UnitController(UnitModel model, GameObject root, GameObject shape, SpawnData spawnData, Material color,
            float size)
        {
            _model = model;
            var obj = GameObject.Instantiate(root, spawnData.Position, spawnData.Rotation).GetComponent<UnitView>();
            GameObject.Instantiate(shape, obj.transform);
            _view = obj.GetComponent<UnitView>();
            _view.Init(color, size);
            
            IdleState = new IdleState(this);
            DeadState = new DeadState(this);
            FightingState = new FightingState(this);
            MovingToTargetState = new MovingToTargetState(this);
            SearchingForTargetState = new SearchingForTargetState(this);
            
            _currentState = IdleState;
            
            ServiceLocator.Get<UpdateLocalService>().RegisterObject(this);
        }

        public void SetActive(bool isOn)
        {
            _model.SetIsActive(isOn);
            _currentState = SearchingForTargetState;
        }

        public void UpdateLocal(float deltaTime)
        {
            if (_model.IsActive)
            {
                _currentState.UpdateLocal(deltaTime);
            }
        }
        
        public void SetState(UnitStateBase newState)
        {
            _currentState = newState;
        }

        public void Dispose()
        {
            ServiceLocator.Get<UpdateLocalService>().UnRegisterObject(this);
            _currentState.Dispose();
            _currentState = null;
            _model = null;
            GameObject.Destroy(_view.gameObject);
            _view = null;
        }
    }
}