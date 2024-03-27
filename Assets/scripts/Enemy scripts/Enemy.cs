using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
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

    private RotateClass player;

    private TextMeshProUGUI _scoreLabel;

    private ParticleSystem _blood;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RotateClass>();
        obj = GameObject.Find("1");
        _scoreLabel = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();

        _scoreLabel.text = $"Кашель: {player.scoreCount}";
    
        _blood = transform.Find("BloodParticle").GetComponent<ParticleSystem>();
        _blood.Stop();
    }
    private void Update()
    {
        obj.GetComponent<Animator>().SetBool("KillFemka", true);
        if (health <= 0)
        {
            Destroy(gameObject);
            GetMoney();
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    private void GetMoney()
    {
        player.scoreCount += 2;
        _scoreLabel.text = $"Кашель: {player.scoreCount}";
        SaveSystem.SavePlayer(player);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        _blood.Play();
    }
}
