using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private float speed,  maxDist, countDown;
    [SerializeField] private GameObject[] players;
    private float timer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        timer = Time.time + countDown;
    }

    private void FixedUpdate()
    {
        if (Time.time > timer)
        { Destroy(this); }

        foreach (GameObject player in players)
        {
            if (player.name == "Purple(Clone)") continue;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            Vector2 force = transform.position - player.transform.position;
            if (force.magnitude >= maxDist) continue;
            rb.AddForce(force * speed);
        }
    }
}
