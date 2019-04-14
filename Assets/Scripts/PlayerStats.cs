using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public Rigidbody2D rigBody;
    public float recoilVelocity;
    
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        health = 3;
    }

    public void Hurt()
    {
        health--;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            ContactPoint2D[] point = other.contacts;
            {
                if (point[0].normal.y >= 0.9f)
                {
                    rigBody.AddForce(new Vector2(0f, recoilVelocity));
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
}
