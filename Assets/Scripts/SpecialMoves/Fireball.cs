using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : SpecialMoveBase
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;

    public override void Special()
    {
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }
}
