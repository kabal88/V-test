using Interfaces;
using Libraries;
using Models;
using Services;
using System;
using System.Linq;
using System.Transactions;
using Data;
using Factories;
using Helpers;
using Systems;
using Views;


namespace Controllers
{
    public class GameController : IUpdatable, IFixUpdatable, IDisposable
    {
        private GameModel _model;
        private Library _library;
        private UpdateLocalService _updateLocalService;
        private FixUpdateLocalService _fixUpdateLocalService;
        private SpawnService _spawnService;
        private GameUIController _gameUIController;
        private UnitFactory _unitFactory;
        private TargetService _targetService;


        public GameController(GameModel gameModel, Library library, GameUIView gameUi)
        {
            _model = gameModel;
            _library = library;
            _gameUIController = new GameUIController(gameUi);
        }

        public void Init()
        {
            _updateLocalService = new UpdateLocalService();
            ServiceLocator.SetService(_updateLocalService);
            _fixUpdateLocalService = new FixUpdateLocalService();
            ServiceLocator.SetService(_fixUpdateLocalService);
            _spawnService = new SpawnService();
            ServiceLocator.SetService(_spawnService);
            _spawnService.Init();
            _targetService = new TargetService();
            ServiceLocator.SetService(_targetService);

            _unitFactory = new UnitFactory(_library);
            PrepareAllArmies();

            _gameUIController.StartButtonClicked += OnStartGame;
            _gameUIController.RerollArmyButtonClicked += OnRerollArmy;
        }

        private void OnStartGame()
        {
            _gameUIController.SetUIActive(false);

            foreach (var unit in _model.UnitsOnField)
            {
                unit.SetActive(true);
            }
        }

        private void OnRerollArmy(int sideID)
        {
            DestroyUnits(sideID);

            _spawnService.ClearSpawnPoints(sideID);

            foreach (var setting in _model.SideRandomSettings.Where(settings => settings.SideID == sideID))
            {
                PrepareArmy(setting);
            }
        }

        private void OnUnitDead(int sideID)
        {
            var count = _model.GetObjectsByPredicate(unit => unit.Side == sideID & unit.IsAlive).Count();
            if (count <= 0)
            {
                Restart();
            }
        }

        private void Restart()
        {
            foreach (var sideRandomSetting in _model.SideRandomSettings)
            {
                _spawnService.ClearSpawnPoints(sideRandomSetting.SideID);
                DestroyUnits(sideRandomSetting.SideID);
                PrepareArmy(sideRandomSetting);
            }
            
            _gameUIController.SetUIActive(true);
        }

        private void DestroyUnits(int sideID)
        {
            var units = _model.GetObjectsByPredicate(unit => unit.Side == sideID).ToArray();

            foreach (var unit in units)
            {
                unit.Dispose();
                unit.Dead -= OnUnitDead;
                _targetService.UnRegisterObject(unit);
                _model.UnRegisterObject(unit);
            }
        }

        private void PrepareAllArmies()
        {
            foreach (var setting in _model.SideRandomSettings)
            {
                PrepareArmy(setting);
                _gameUIController.AddSide(setting.SideID);
            }
        }

        private void PrepareArmy(SideSettings setting)
        {
            for (var i = 0; i < setting.ArmySize; i++)
            {
                var spawnList = _spawnService
                    .GetObjectsByPredicate(point => point.Side == setting.SideID && point.IsEmpty);

                var spawnPoint = spawnList.FirstOrDefault();

                var config = new UnitConfig()
                {
                    BaseUnitID = setting.BaseUnitCharacteristics.RandomID(),
                    ColorID = setting.ColorCharacteristics.RandomID(),
                    SideID = setting.SideID,
                    SizeID = setting.SizeCharacteristics.RandomID(),
                    ShapeID = setting.ShapeCharacteristics.RandomID()
                };

                var unit = _unitFactory.CreateUnit(config, spawnPoint);
                unit.Dead += OnUnitDead;
                _model.RegisterObject(unit);
                _targetService.RegisterObject(unit);
            }
        }

        public void UpdateLocal(float deltaTime)
        {
            _updateLocalService.UpdateLocal(deltaTime);
        }

        public void FixedUpdateLocal()
        {
            _fixUpdateLocalService.FixedUpdateLocal();
        }

        public void Dispose()
        {
        }
    }
}