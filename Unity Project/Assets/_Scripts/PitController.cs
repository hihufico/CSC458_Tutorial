using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour {

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
            GameObject Checkpoint = GetNearestCheckpoint();
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            playerStats.takeDamage(2);
            collision.transform.position = Checkpoint.transform.position;
        }
    }

    GameObject GetNearestCheckpoint()
    {
        GameObject[] Check;
        Check = GameObject.FindGameObjectsWithTag("Checkpoint");
        float mindistance= Mathf.Infinity;
        GameObject BestCheckpoint= null;
        foreach (GameObject C in Check)
        {
            if(C.GetComponent<CheckpointController>().Checked)
            {
                float distance = (transform.position - C.transform.position).sqrMagnitude;
                if(distance<mindistance)
                {
                    mindistance = distance;
                    BestCheckpoint = C;
                }
            }
            
        }
        return BestCheckpoint;
    }
}
