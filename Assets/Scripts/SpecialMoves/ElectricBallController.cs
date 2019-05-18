using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBallController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Idle();
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(10);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase enemyPlayer = collision.GetComponent<PlayerBase>();
        if (enemyPlayer != null)
        {
            enemyPlayer.OnStun();
            Destroy(this);
        }

        Destroy(this);
    }
}
