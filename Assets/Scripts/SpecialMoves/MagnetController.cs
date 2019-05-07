using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleColider;
    [SerializeField] private float startRad, finalRad, rad;
    private Transform thingToPull;

    private void Update()
    {
        circleColider.radius = Mathf.Lerp(startRad, finalRad, rad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase enemyPlayer = collision.GetComponent<PlayerBase>();
        if (enemyPlayer != null)
        {
            thingToPull = collision.transform;
            Vector2 D = transform.position - thingToPull.position; // line from crate to player
            float dist = D.magnitude;
            Vector2 pullDir = D.normalized; // short blue arrow from crate to player

            if (dist > 50) thingToPull = null; // lose tracking if too far
            else if (dist > 3)
            { // don't pull if too close

                // this is the same math to apply fake gravity. 10 = normal gravity
                float pullF = 10;

                // for fun, pull a little bit more if further away:
                // (so, random, optional junk):
                float pullForDist = (dist - 3) / 2.0f;
                if (pullForDist > 20) pullForDist = 20;
                pullF += pullForDist;

                // Now apply to pull force, using standard meters/sec converted
                //    into meters/frame:
                Rigidbody2D rigibody2 = thingToPull.GetComponent<Rigidbody2D>();
                rigibody2.velocity += pullDir * (pullF * Time.deltaTime);
            }
        }
    }
}
