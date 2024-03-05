using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneneChanger : MonoBehaviour
{
    public int sceneIndex;
    public RectTransform anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Entered");

        if (other.CompareTag("Player"))
        {
            print("Changing scene...");
            SaveSystem.SavePlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<RotateClass>());
            anim.gameObject.SetActive(true);
        }
    }

    public void offAnim()
    {
        anim.gameObject.SetActive(false);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
