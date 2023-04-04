using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuManagerUI : MonoBehaviour
    {
        public event Action OnStartedGame;
        public event Action OnQuitedGame;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStart);
            _quitButton.onClick.AddListener(OnQuit);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStart);
            _quitButton.onClick.RemoveListener(OnQuit);
        }

        private void OnStart()
        {
            OnStartedGame?.Invoke();
        }

        private void OnQuit()
        {
            OnQuitedGame?.Invoke();
        }
    }
}