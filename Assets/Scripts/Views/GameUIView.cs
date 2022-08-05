using System;
using UI;
using UnityEngine;

namespace Views
{
    public class GameUIView : MonoBehaviour
    {
        public event Action StartButtonClicked;
        public event Action RerollTopArmyButtonClicked;
        public event Action RerollBottomArmyButtonClicked;

        private StartButton _startButton;
        private RerollTopArmyButton _rerollTopArmyButton;
        private RerollBottomArmyButton _rerollBottomArmyButton;
        
        public void Init()
        {
            _startButton = GetComponentInChildren<StartButton>();
            _startButton.Init();
            _startButton.Button.onClick.AddListener(OnStartButtonClicked);
            
            _rerollTopArmyButton = GetComponentInChildren<RerollTopArmyButton>();
            _rerollTopArmyButton.Init();
            _rerollTopArmyButton.Button.onClick.AddListener(OnRerollTopArmyButtonClicked);
            
            _rerollBottomArmyButton = GetComponentInChildren<RerollBottomArmyButton>();
            _rerollBottomArmyButton.Init();
            _rerollBottomArmyButton.Button.onClick.AddListener(OnRerollBottomArmyButtonClicked);
        }

        public void SetActive(bool isOn)
        {
            gameObject.SetActive(isOn);
        }
        
        private void OnStartButtonClicked()
        {
            StartButtonClicked?.Invoke();
        }

        private void OnRerollTopArmyButtonClicked()
        {
            RerollTopArmyButtonClicked?.Invoke();
        }

        private void OnRerollBottomArmyButtonClicked()
        {
            RerollBottomArmyButtonClicked?.Invoke();
        }
    }
}