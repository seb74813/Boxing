using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health, numOfHearts;
    Rigidbody2D rigBody;
    public float recoilVelocity;
    public PlayerMovement playerMovement;
    

    public Image[] hearts;
    public Sprite fullHeart, emptyheart;
    
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        Health();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown(playerMovement.special))
        {
            
        }
    }

    public void Health()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Hurt()
    {
        health--;
        Health();
    }
    public void Void()
    {
        health--;
        Health();
        this.transform.position = new Vector2(0.0f, 0.0f);
        Debug.Log("Player has fallen off map");
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
        if (other.collider.tag == "Void")
        {
            Void();
        }
    }
}
