using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

 public CharacterController2D controller;
 public Animator animator;

    public float runSpeed = 40f;
    public int player;
    float horizontalMove = 0f;
    bool jump = false;
    public string horizontal, up, special;

    private void Start()
    {
        if (player == 1)
        {
            horizontal = "Horizontal";
            up = "Jump";
            special = "Fire1";
        }
        if (player == 2)
        {
            horizontal = "Horizontal2";
            up = "Jump2";
            special = "Fire2";
        }
    }


	// Update is called once per frame
    
	void Update () {

       horizontalMove = Input.GetAxisRaw(horizontal) * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown(up))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
       
	}


    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
