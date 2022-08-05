using System;
using System.Collections.Generic;
using Views;

namespace Controllers
{
    public class GameUIController : IDisposable
    {
        public event Action StartButtonClicked;
        public event Action<int> RerollArmyButtonClicked;

        private List<int> _sidesID;
        private GameUIView _view;

        public GameUIController(GameUIView view)
        {
            _view = view;
            _sidesID = new List<int>();
            _view.Init();
            _view.StartButtonClicked += OnStartButtonClicked;
            _view.RerollTopArmyButtonClicked += OnRerollTopArmyButtonClicked;
            _view.RerollBottomArmyButtonClicked += OnRerollBottomArmyButtonClicked;
        }

        public void AddSide(int sidesID)
        {
            _sidesID.Add(sidesID);
        }

        public void SetUIActive(bool isOn)
        {
            _view.SetActive(isOn);
        }

        private void OnStartButtonClicked()
        {
            StartButtonClicked?.Invoke();
        }

        private void OnRerollTopArmyButtonClicked()
        {
            RerollArmyButtonClicked?.Invoke(_sidesID[1]);
        }

        private void OnRerollBottomArmyButtonClicked()
        {
            RerollArmyButtonClicked?.Invoke(_sidesID[0]);
        }

        public void Dispose()
        {
            _view.StartButtonClicked -= OnStartButtonClicked;
            _view.RerollTopArmyButtonClicked -= OnRerollTopArmyButtonClicked;
            _view.RerollBottomArmyButtonClicked -= OnRerollBottomArmyButtonClicked;
        }
    }
}