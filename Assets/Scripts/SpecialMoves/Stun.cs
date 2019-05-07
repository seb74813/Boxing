using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : SpecialMoveBase
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject electricBall;

    public override void Special()
    {
        Instantiate(electricBall, firePoint.position, firePoint.rotation);
    }
}
