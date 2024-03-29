using UnityEngine;
using System.Collections;

public class RotateClass : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] 
    private float _speed;
    private Animator _anim;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        LookAtMouse();
        Move();
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
    }

    private void Move()
    {
        var input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
        _rigidbody.velocity = input.normalized * _speed;

        if (input.y < 0 || input.y > 0 || input.x < 0 || input.x > 0)
        {
            _anim.SetBool("is running", true);
        }
        else
        {
            _anim.SetBool("is running", false);
        }
    }
}