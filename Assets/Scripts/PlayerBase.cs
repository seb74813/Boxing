using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    #region "Refrences"
    [Header("Script Refrences")]
    [SerializeField] private CharacterController2D characterController2D;
    [SerializeField] private Animator animator;
    [SerializeField] private SpecialMoveBase specialMove;

    [Header("Movement Refrences")]
    public Rigidbody2D rigBody;
    [SerializeField] private float recoilVelocity;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private int player;
    [SerializeField] private float horizontalMove = 0f;
    [SerializeField] private bool jump = false;
    [SerializeField] private string horizontal, up, special, down;
    [SerializeField] private float coolDown;
    [SerializeField] private Transform coolDownLoc;
    [SerializeField] private GameObject coolDownEffect, stunEffect, freezeEffect, invincEffect;
    private bool cooledDown, active;
    private float nextFireTime, stunTime;
    private BoxCollider2D boxCollider;
    private GameObject freezeEffectcurrent = null;
    private GameObject stunEffectCurrent = null;
    private GameObject invincEffectCurrent = null;
    [SerializeField] private PhysicsMaterial2D slippery, stun;


    [Header("Health System")]
    [SerializeField] private int health;
    [SerializeField] private int numOfHearts;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private Sprite fullHeart, emptyheart;
    private float nextHit;
    #endregion

    #region "Methods"
    /// <summary>
    /// Start method runs code when the scene is loaded
    /// </summary>
    private void Start()
    {
        //This logic determines which player this is and sets the controls and health system
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        if ((PlayerPrefs.GetString("Player1") + "(Clone)") == this.name)
        {
            horizontal = "Horizontal";
            up = "Jump";
            special = "Fire1";
            down = "Down";
            GameObject icon = GameObject.Find("Player1/Icon");
            Image iconImage = icon.GetComponent<Image>();
            iconImage.sprite = playerSprite.sprite;
            GameObject heart1 = GameObject.Find("Player1/Heart1");
            GameObject heart2 = GameObject.Find("Player1/Heart2");
            GameObject heart3 = GameObject.Find("Player1/Heart3");
            hearts[0] = heart1;
            hearts[1] = heart2;
            hearts[2] = heart3;
            player = 1;
        }
        if ((PlayerPrefs.GetString("Player2") + "(Clone)") == this.name)
        {
            horizontal = "Horizontal2";
            up = "Jump2";
            special = "Fire2";
            down = "Down2";
            GameObject icon = GameObject.Find("Player2/Icon");
            Image iconImage = icon.GetComponent<Image>();
            iconImage.sprite = playerSprite.sprite;
            GameObject heart1 = GameObject.Find("Player2/Heart1");
            GameObject heart2 = GameObject.Find("Player2/Heart2");
            GameObject heart3 = GameObject.Find("Player2/Heart3");
            hearts[0] = heart1;
            hearts[1] = heart2;
            hearts[2] = heart3;
            player = 2;
        }
        //This gets physics component
        rigBody = GetComponent<Rigidbody2D>();
        //These set the health and number of hearts and then runs the Health method
        health = 3;
        numOfHearts = 3;
        Health();
    }
    
    /// <summary>
    /// Update method runs every frame. This one runs the controls of the player
    /// </summary>
    private void Update()
    {
        //This stops the player from moving if they are stunned
        if (Time.time > stunTime)
        {
            //This gets the direction of horizontal movement
            horizontalMove = Input.GetAxisRaw(horizontal) * runSpeed;
            //This sends the magnitude of horizontal movement to animator
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //This sees if jump button has been pressed
            if (Input.GetButtonDown(up))
            {
                //Sets jump to true and sends it to the animator
                jump = true;
                animator.SetBool("Jump", true);
            }
            //This sees if the down button has been pressed
            if (Input.GetButtonDown(down))
            {
                //This runs a method in the CharacterController2D called PlatformShift
                characterController2D.PlatformShift();
            }
            //This sees if the cool down on the special move has elapsed
            if (Time.time > nextFireTime)
            {
                //This plays a cool down effect once per use of special move
                if (cooledDown == false)
                {
                    Instantiate(coolDownEffect, coolDownLoc.position, coolDownLoc.rotation);
                    cooledDown = true;
                }
                //This sees if the special move button has been pressed
                if (Input.GetButtonDown(special))
                {
                    //Runs the Special method in the refrenced special move script on chracter
                    specialMove.Special();
                    //This sets a timer for a cooldown
                    nextFireTime = Time.time + coolDown;
                    cooledDown = false;
                }
            }
        }
    }

    /// <summary>
    /// FixedUpdate runs code on a fixed time. Fixed Update is best to use physics rather than update which is regular
    /// </summary>
    private void FixedUpdate()
    {
        //This checks if the stun time has elapsed
        if (Time.time > stunTime)
        {
            //This uses the refrenced CharacterController2D script's method MOve to move the character
            characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
            if (freezeEffectcurrent != null)
            {
                freezeEffectcurrent.SetActive(false);
            }
            if (stunEffectCurrent != null)
            {
                boxCollider.sharedMaterial = slippery;
                stunEffectCurrent.SetActive(false);
            }
        }
        if (Time.time > nextHit)
        {
            if (invincEffectCurrent != null)
            {
                invincEffectCurrent.SetActive(false);
            }
        }
    }

    /// <summary>
    /// OnLanding method is used to tell the animator when to stop jump animation
    /// </summary>
    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    /// <summary>
    /// OnStun method is used by Stun gameobject to start a timer 
    /// </summary>
    public void OnStun()
    {
        stunTime = Time.time + 5;
        //This plays an effect which is shown when stunned
        if (stunEffectCurrent == null)
        {
            stunEffectCurrent = Instantiate(stunEffect, transform.position, transform.rotation);
            stunEffectCurrent.transform.parent = gameObject.transform;
        }
        else if (stunEffectCurrent != null)
        {
            freezeEffectcurrent.SetActive(true);
        }
        characterController2D.m_IsStun = true;
        boxCollider.sharedMaterial = stun;
        rigBody.velocity = new Vector2(0f, 0f);
    }

    public void OnFreeze()
    {
        stunTime = Time.time + 3;
        if (freezeEffectcurrent == null)
        {
            freezeEffectcurrent = Instantiate(freezeEffect, transform.position, transform.rotation);
            freezeEffectcurrent.transform.parent = gameObject.transform;
        }
        else if (freezeEffectcurrent != null)
        {
            freezeEffectcurrent.SetActive(true);
        }
        characterController2D.m_IsStun = true;
    }

    /// <summary>
    /// Health method displays the current health to the players
    /// </summary>
    private void Health()
    {
        //Checks if health is greater than number of hearts and then fixes it
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        //Checks if player has died
        else if (health <= 0)
        {
            //Logic to tell WinScreen who won
            if (player == 1)
            {
                PlayerPrefs.SetInt("Winner", 2);
            }
            if (player == 2)
            {
                PlayerPrefs.SetInt("Winner", 1);
            }
            //Changes the scene
            SceneManager.LoadScene("WinScreen");
        }
        //Displays the hearts to the players and shows if they are empty of not
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                Image heart = hearts[i].GetComponent<Image>() as Image;
                heart.sprite = fullHeart;
            }
            else
            {
                Image heart = hearts[i].GetComponent<Image>() as Image;
                heart.sprite = emptyheart;
            }

            if (i < numOfHearts)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Hurt method lowers the players health
    /// </summary>
    public void Hurt()
    {
        //This set a timer to see when player can next be hurt
        if (Time.time > nextHit)
        {
            if (invincEffectCurrent != null)
            {
                invincEffectCurrent.SetActive(false);
            }
            //Lowers health and then plays Health method to display result
            health--;
            Health();
            //Starts timer
            nextHit = Time.time + 3;
            if (invincEffectCurrent == null)
            {
                invincEffectCurrent = Instantiate(invincEffect, transform.position, transform.rotation);
                invincEffectCurrent.transform.parent = gameObject.transform;
            }
            else if (invincEffectCurrent)
            {
                invincEffectCurrent.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Void method activates when players fall into the void
    /// </summary>
    private void Void()
    {
        //Lowers health and displays it
        health--;
        Health();
        //Teleports the player to land
        this.transform.position = new Vector2(0.0f, 0.0f);
    }

    /// <summary>
    /// This method detects when another collider hits this collider and runs the code
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Checks if the other object is a player
        if (other.collider.tag == "Player")
        {
            //Finds the point of contact of collision
            ContactPoint2D[] point = other.contacts;
            {
                //Checks if the player landed on the top of this object or landed on another player
                if (point[0].normal.y >= 0.9f)
                {
                    rigBody.AddForce(new Vector2(0f, recoilVelocity));
                }
                else if (point[0].normal.y <= -0.9f)
                {
                    //Runs the hurt method if other player lands on the top of this object
                    Hurt();
                }
            }
        }
        //Checks if the collision is with the void object and then runs Void method
        if (other.collider.tag == "Void")
        {
            Void();
        }
    }
    #endregion
}
