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
            anim.gameObject.SetActive(true);
            //
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
