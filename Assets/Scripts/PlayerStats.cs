using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public Rigidbody2D rigBody;
    
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        health = 3;
    }

    void Update()
    {
        
    }

    public void Hurt()
    {
        health--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the collision is with a player object
        ContactPoint2D[] point = collision.contacts;
        {
            if (point[0].normal.y >= 0.9f)
            {
                rigBody.AddForce(new Vector2(0f, 1050f));
                Debug.Log("You have bopped");
            }
            else if (point[0].normal.y <= -0.9f)
            {
                Debug.Log("You have been bopped");
                Hurt();
            }
        }
    }
}
