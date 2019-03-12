using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public int amount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            PlayerStats ps = collision.GetComponent<PlayerStats>();
            ps.AddScore(amount);
            Destroy(this.gameObject);
        }
    }
}
