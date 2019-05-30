using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SpecialMoveBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private CharacterController2D controller2D;

    public override void Special()
    {
        controller2D = GetComponent<CharacterController2D>();

        if (controller2D.m_FacingRight)
        {
            rb.AddForce(new Vector2(speed, 0f));
        }
        if (controller2D.m_FacingRight == false)
        {
            rb.AddForce(new Vector2(-1 * speed, 0f));
        }
    }
}
