using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gust : SpecialMoveBase
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject gust;

    public override void Special()
    {
        Instantiate(gust, firePoint.position, firePoint.rotation);
    }
}
