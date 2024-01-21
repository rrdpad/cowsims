using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsFP : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D _rigidbody;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));

        if (input.y < 0 || input.y > 0 || input.x < 0 || input.x > 0)
        {
            anim.SetBool("isRunFP", true);
        }
        else
        {
            anim.SetBool("isRunFP", false);
        }

    }
}
