using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            Rigidbody2D playerRigid = collision.GetComponent<Rigidbody2D>();
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            
                playerStats.takeDamage(1);
            
            bool isgrounded = playerController.IsGrounded();
            if (isgrounded)
            {
                if (collision.transform.position.x < transform.position.x)
                {

                    playerRigid.AddForce(new Vector2(-800, 0));

                }
                else
                {

                    playerRigid.AddForce(new Vector2(800, 0));
                }
            }
            else
            {
                if (collision.transform.position.x < transform.position.x)
                {
                     playerRigid.AddForce(new Vector2(-800, 800));
                }
                else
                {

                    playerRigid.AddForce(new Vector2(800, 800));
                }
            }

        }
    }
}
