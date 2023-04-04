using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private MenuManagerUI _menuManagerUI;
        [SerializeField] private LevelManager _levelManager;

        private void OnEnable()
        {
            _menuManagerUI.OnStartedGame += StartGame;
            _menuManagerUI.OnQuitedGame += QuitGame;
        }

        private void OnDisable()
        {
            _menuManagerUI.OnStartedGame -= StartGame;
            _menuManagerUI.OnQuitedGame -= QuitGame;
        }

        private void StartGame()
        {
            _levelManager.StartGame();
        }

        private void QuitGame()
        {
            _levelManager.QuitGame();
        }
    }
}