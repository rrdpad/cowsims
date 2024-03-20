using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        RotateClass.gamePaused = false;
    }

    //TODO: сделать кнопку выхода в меню
    public void Exit()
    {
        Application.Quit();
    }
}
