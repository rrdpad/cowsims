using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    private AudioSource aS;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private ParticleSystem _bulletParticle;


    private void Awake()
    {
        aS = GetComponent<AudioSource>();
        _bulletParticle = GameObject.Find("FireEffect").GetComponent<ParticleSystem>();
        _bulletParticle.Stop();
    }

    void Update()
    {
        if (RotateClass.gamePaused == true) return;

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                _bulletParticle.Play();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (gameObject.GetComponent<AudioSource>() != null)
        {
            if (Input.GetMouseButtonDown(0) | Input.GetMouseButtonUp(0) == true)
            {
                aS.Play();
            }
            if (Input.GetMouseButton(0) == false && aS.isPlaying)
            {
                aS.Stop();
            }
        }
    }
}
