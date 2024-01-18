using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personage_mechanics : MonoBehaviour
{
    public float speed;

    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (direction.x == 0)
        {
            anim.SetBool("is running", false);
        }
        else
        {
            anim.SetBool("is running", true);
        }

        if (!facingRight && direction.x > 0)
        {
            Flip();
        }
        else if (!facingRight && direction.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
