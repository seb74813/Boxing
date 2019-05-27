using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffectController : MonoBehaviour
{
    [SerializeField] private float countDown;
    private float timer;

    void Start()
    {
        timer = Time.time + countDown;
        Debug.Log("Timer start " + timer);
    }

    void Update()
    {
        if (Time.time > timer)
        {
            Debug.Log("Timer done");
            Destroy(gameObject);
        }
    }
}
