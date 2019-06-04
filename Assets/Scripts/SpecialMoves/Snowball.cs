using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : SpecialMoveBase
{
    [SerializeField] private GameObject firePoint, effect;
    public override void Special()
    {
        Instantiate(effect , firePoint.transform);
    }
}
