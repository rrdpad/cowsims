using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;

    private Transform _player;

    private Rigidbody2D _rigidbody;
    private Vector3 v_diff;
    private float atan2;
    private float distance;
    [SerializeField]
    public float speed = 50f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<RotateClass>().transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rotation();
        Walk();
    }
    private void Rotation()
    {
        v_diff = (_player.position - transform.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90f);
    }

    private void Walk()
    {
        distance = Vector2.Distance(transform.position, _player.position);
        Vector2 direction = _player.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * (float)Time.deltaTime);
    }

}
