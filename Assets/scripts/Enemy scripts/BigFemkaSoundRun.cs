using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFemkaSoundRun : MonoBehaviour
{
    private AudioSource aS;

    private void Awake()
    {
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            aS.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            aS.Stop();
        }
    }
}
