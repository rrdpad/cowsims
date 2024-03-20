using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public RotateClass player;

    public int sceneIndex = 1;

    void Start()
    {
        if (SceneManager.sceneCount == 3)
            player = GameObject.Find("player").GetComponent<RotateClass>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            LoadNextLevel();
            SavePLayer();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        SavePLayer();
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        SavePLayer();
    }

    public void LoadMenuLevel()
    {
        StartCoroutine(LoadLevel(0));
    }

    private void SavePLayer()
    {
        if (SceneManager.sceneCount == 3)
            SaveSystem.SavePlayer(player);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
