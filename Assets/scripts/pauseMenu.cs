using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        RotateClass.gamePaused = false;
    }

    public void ExitMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
