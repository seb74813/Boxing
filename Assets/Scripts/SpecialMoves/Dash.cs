using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SpecialMoveBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Animator animator;
    private CharacterController2D controller2D;
    private float timerSpecial;
    public override void Special()
    {
        controller2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        timerSpecial = Time.time + 0.3f;
        animator.SetBool("Dash", true);

        if (controller2D.m_FacingRight)
        {
            rb.AddForce(new Vector2(speed, 0f));
        }
        if (controller2D.m_FacingRight == false)
        {
            rb.AddForce(new Vector2(-1 * speed, 0f));
        }
    }
    private void Update()
    {
        if (Time.time > timerSpecial)
        {
            animator.SetBool("Dash", false);
        }
    }
}
