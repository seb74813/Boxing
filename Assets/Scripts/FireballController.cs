using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactEffect;
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
            enemyPlayer.Hurt();
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
