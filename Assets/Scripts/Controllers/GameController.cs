using Interfaces;
using Libraries;
using Models;
using Services;
using System;
using UI;
using UnityEngine;
using Views;


namespace Controllers
{
    public class GameController : IUpdatable, IFixUpdatable, IDisposable
    {
        private GameModel _model;
        private Library _library;
        private UpdateLocalService _updateLocalService;
        private FixUpdateLocalService _fixUpdateLocalService;
        private GameUIController _gameUIController;


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