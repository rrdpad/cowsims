using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaGame()
    {
        //TODO: поменять обратно на катсцену
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Debug.Log("GameExit");
        Application.Quit();
    }
}
