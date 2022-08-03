using System;
using Interfaces;
using UI;
using UnityEngine;
using Views;

namespace Controllers
{
    public class GameUIController : IDisposable
    {
        private GameUIView _view;

        public GameUIController(GameUIView view)
        {
            _view = view;
            _view.Init();
        }

        public void Dispose()
        {
        }
    }
}