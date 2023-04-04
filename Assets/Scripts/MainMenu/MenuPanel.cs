using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MainMenu
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private MenuPanelUI _menuPanelUI;
        [SerializeField] private LevelManager _levelManager;
        
        private PlayerInputActionsAsset _playerInputActionsAsset;

        private void Awake()
        {
            _playerInputActionsAsset = new PlayerInputActionsAsset();
        }

        private void OnEnable()
        {
            _playerInputActionsAsset.Player.OpenMenu.performed += OpenMenu;
            _playerInputActionsAsset.Player.OpenMenu.Enable();
            _menuPanelUI.OnYesButton += LoadMenu;
            _menuPanelUI.OnNoButton += ContinuePlaying;
        }

        private void OnDisable()
        {
            _playerInputActionsAsset.Player.OpenMenu.performed -= OpenMenu;
            _playerInputActionsAsset.Player.OpenMenu.Disable();
            _menuPanelUI.OnYesButton -= LoadMenu;
            _menuPanelUI.OnNoButton -= ContinuePlaying;
        }

        private void OpenMenu(InputAction.CallbackContext context)
        {
            Time.timeScale = 0;
            _menuPanelUI.gameObject.SetActive(true);
        }

        private void LoadMenu()
        {
            Time.timeScale = 1;
            _levelManager.OpenMenu();
        }

        private void ContinuePlaying()
        {
            Time.timeScale = 1;
            _menuPanelUI.gameObject.SetActive(false);
        }
    }
}