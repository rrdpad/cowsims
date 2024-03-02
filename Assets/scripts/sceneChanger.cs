using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ScneneChanger : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Entered");

        if (other.CompareTag("Player"))
        {
            print("Changing scene...");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
