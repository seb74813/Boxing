using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    #region "Refrences"
    [Header("Script Refrences")]
    [SerializeField] private CharacterController2D characterController2D;
    [SerializeField] private Animator animator;
    [SerializeField] private SpecialMoveBase specialMove;

    [Header("Movement Refrences")]
    [SerializeField] private Rigidbody2D rigBody;
    [SerializeField] private float recoilVelocity;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private int player;
    [SerializeField] private float horizontalMove = 0f;
    [SerializeField] private bool jump = false;
    [SerializeField] private string horizontal, up, special;

    [Header("Health System")]
    [SerializeField] private int health;
    [SerializeField] private int numOfHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart, emptyheart;
    #endregion

    private void Start()
    {
        if (PlayerPrefs.GetString("Player1") == this.name)
        {
            horizontal = "Horizontal";
            up = "Jump";
            special = "Fire1";
        }
        if (PlayerPrefs.GetString("Player2") == this.name)
        {
            horizontal = "Horizontal2";
            up = "Jump2";
            special = "Fire2";
        }
        rigBody = GetComponent<Rigidbody2D>();
        Health();
    }

    private void Update()
    {
        #region "Player Controls"
        horizontalMove = Input.GetAxisRaw(horizontal) * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown(up))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown(special))
        {
            specialMove.Special();
        }
        #endregion
    }

    private void FixedUpdate()
    {
        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    private void Health()
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

    private void Hurt()
    {
        health--;
        Health();
    }

    private void Void()
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

