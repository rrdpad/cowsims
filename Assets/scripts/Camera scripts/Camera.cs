using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform _player;
    private const float CameraSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var position = _player.position;
        var charPos = new Vector3(position.x,position.y,-10f);
		transform.position = Vector3.Slerp(transform.position,charPos, (float)Time.deltaTime * CameraSpeed);
    }
}
