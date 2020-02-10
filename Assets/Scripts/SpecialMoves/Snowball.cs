using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : SpecialMoveBase
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject effect;
    public override void Special()
    {
        Instantiate(effect , firePoint.position, firePoint.rotation);
    }
}
