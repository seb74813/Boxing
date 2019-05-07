using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : SpecialMoveBase
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public override void Special()
    {
        rb.AddForce(new Vector2(0f, speed));
    }

}
