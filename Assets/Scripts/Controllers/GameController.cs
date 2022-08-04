using Interfaces;
using Libraries;
using Models;
using Services;
using System;
using System.Linq;
using Data;
using Factories;
using Helpers;
using Systems;


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


        public GameController(GameModel gameModel, Library library)
        {
            _model = gameModel;
            _library = library;
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

            _unitFactory = new UnitFactory(_library);
            
            PrepareSideArmies();

        }

        private void PrepareSideArmies()
        {
            foreach (var setting in _model.SideRandomSettings)
            {
                for (var i = 0; i < setting.ArmySize; i++)
                {
                    var spawnList = _spawnService
                        .GetObjectsByPredicate(point => point.Side == setting.SideID && point.IsEmpty);
                    
                    var spawnPoint  =  spawnList.FirstOrDefault();

                    var config = new UnitConfig()
                    {
                        BaseUnitID = setting.BaseUnitCharacteristics.RandomID(),
                        ColorID = setting.ColorCharacteristics.RandomID(),
                        SideID = setting.SideID,
                        SizeID = setting.SizeCharacteristics.RandomID(),
                        ShapeID = setting.ShapeCharacteristics.RandomID()
                    };

                    _unitFactory.CreateUnit(config, spawnPoint);
                }
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