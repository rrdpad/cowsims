using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform player;
    private const float CameraSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var charPos = new Vector3(player.position.x,player.position.y,-10f);
		transform.position = Vector3.Slerp(transform.position,charPos, (float)Time.deltaTime * CameraSpeed);
    }
}
