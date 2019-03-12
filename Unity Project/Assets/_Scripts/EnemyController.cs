using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int mvt_speed;
    int direction;
    Rigidbody2D EnemyRigid;
    public float damageforce;
	// Use this for initialization
	void Awake () {
        float rand = Random.Range(0, 1.0f);
        if (rand < 0.5)
            direction = -1;
        else
            direction = 1;

        EnemyRigid = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        EnemyRigid.velocity = new Vector2(direction * mvt_speed, EnemyRigid.velocity.y);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy" || collision.tag == "Wall")
        {
            direction *= -1;
        }

       
    }
}

