using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : SpecialMoveBase
{
    [SerializeField] private float speed, maxDist, countDown;
    [SerializeField] private GameObject[] players;
    [SerializeField] private Animator animator;
    private float timer;
    private bool active;

    public override void Special()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        active = true;
        timer = Time.time + countDown;
        animator.SetBool("Magnet" , true);
    }

    private void FixedUpdate()
    {
        if (Time.time > timer)
        { 
            active = false;
            animator.SetBool("Magnet", false);
        }

        if (active)
        {
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
}
