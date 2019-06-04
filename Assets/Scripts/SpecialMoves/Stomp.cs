using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : SpecialMoveBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Animator animator;
    private CharacterController2D controller2D;
    private bool active;

    private void Start()
    {
        controller2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        active = false;
    }

    public override void Special()
    {
        animator.SetBool("Stomp", true);
        rb.AddForce(new Vector2(0f, -1 * speed));
        active = true;  
    }

    private void Update()
    {
        if (active == true && controller2D.m_Grounded == true)
        {
            animator.SetBool("Stomp", false);
            active = false;
        }
    }
}
