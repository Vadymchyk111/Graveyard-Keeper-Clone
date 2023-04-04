using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
