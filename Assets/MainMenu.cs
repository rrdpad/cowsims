using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        var filePath = @"./weapons.txt";
        if (!File.Exists(filePath))
        {
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            fileStream.Close();
            File.WriteAllText(filePath, "0 0 0");
        }
    }
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
