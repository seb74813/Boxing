using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustController : MonoBehaviour
{
    [SerializeField] private float speed, force;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Idle();
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase enemyPlayer = collision.GetComponent<PlayerBase>();
        if (enemyPlayer != null)
        {
            enemyPlayer.rigBody.velocity = rb.velocity * force;
        }

        Destroy(gameObject);
    }
}
