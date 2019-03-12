using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    bool isGrounded, isJumping;
    Rigidbody2D Player_Rigid;
    RaycastHit2D Raycast;
    bool isfacingright=true;
    float speed;
    Animator player_anim;
    // Use this for initialization
    void Start () {
        Player_Rigid = GetComponent<Rigidbody2D>();
        player_anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        speed = Input.GetAxis("Horizontal");
        Player_Rigid.velocity= new Vector2(speed * maxSpeed, Player_Rigid.velocity.y);

        player_anim.SetFloat("Speed", Mathf.Abs(speed));

        if (isGrounded )
        {
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_anim.SetBool("Jump", true);
                Player_Rigid.velocity = new Vector2(Player_Rigid.velocity.x, 0);
                Player_Rigid.AddForce(new Vector2(0, jumpForce));
                isJumping = true;

               
            }
            return;
        }
        if (isJumping)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player_Rigid.velocity = new Vector2(Player_Rigid.velocity.x, 0);
                Player_Rigid.AddForce(new Vector2(0, jumpForce));
                isJumping = false;

               
            }
            return;
        }
	}
    void Update()
    {
        isGrounded = IsGrounded();

        if(speed<0 && isfacingright)
        {
            Flip();
            isfacingright = false;
        }
        if(speed>0 && !isfacingright)
        {
            Flip();
            isfacingright = true;
        }
    }

   

    public bool IsGrounded()
    {
        Raycast = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, groundLayer);
        if (Raycast.collider == null)
            return false;
        else
        {
            player_anim.SetBool("Jump", false);
            return true;
        }
       }
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
