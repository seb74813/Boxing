using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase enemyPlayer = collision.GetComponent<PlayerBase>();
        if (enemyPlayer != null)
        {
            enemyPlayer.OnFreeze();
            Destroy(gameObject);
            Destroy(this);
        }

        Destroy(gameObject);
    }

}
