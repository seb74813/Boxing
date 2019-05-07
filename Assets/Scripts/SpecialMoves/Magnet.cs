using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : SpecialMoveBase
{
    [SerializeField] private GameObject radius;

    public override void Special()
    {
        Instantiate(radius, transform.position, transform.rotation);
    }
}
