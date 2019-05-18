using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SpecialMoveBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public override void Special()
    {
        rb.AddForce(new Vector2(speed, 0f));
    }
}
