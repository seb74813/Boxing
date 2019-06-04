using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffectContoller : MonoBehaviour
{
    private float freezeTimer;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        freezeTimer = Time.time + 3;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeTimer > Time.time && active == true)
        {
            Destroy(gameObject);
        }
    }
}
