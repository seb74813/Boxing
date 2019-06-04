using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : SpecialMoveBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Animator animator;
    private CharacterController2D controller2D;

    private void Start()
    {
        controller2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    public override void Special()
    {
        animator.SetBool("Stomp", true);
        rb.AddForce(new Vector2(0f, -1 * speed)); 
    }

    private void Update()
    {
        if (controller2D.m_Grounded == true)
        {
            animator.SetBool("Stomp", false);
        }
    }
}
