using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Animator _anim;
    public Animation anim;
    public int health;
    public float speed;
    public GameObject obj;
    public float timeLeft;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
         obj = GameObject.Find("1");
    }
    private void Update()
    {
        obj.GetComponent<Animator>().SetBool("KillFemka", true);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    public void TakeDamage(int damage) 
    { 
        health -= damage;
    }

}
