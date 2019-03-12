using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int health;
    public int score;
    public bool isimmune;
    SpriteRenderer SR;
    private float timeelapsed;
    public float immunityduration;
    // Use this for initialization
    void Start () {
        SR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isimmune)
        {
            timeelapsed += Time.deltaTime;
            if(timeelapsed>immunityduration)
            {
                isimmune = false;
                StopCoroutine("Flashing");
                timeelapsed = 0;
            }
        }
        
    }
    public void takeDamage(int damage)
    {
        if (!isimmune)
        {
            health -= damage;
            isimmune = true;
            StartCoroutine("Flashing");
        }
       
    }
    public void AddScore(int amount)
    {

        score += amount;
        
    }

        IEnumerator Flashing()
    {
        while (true)
        {
            SR.enabled = false;
            yield return new WaitForSeconds(0.1f);
            SR.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

  
}
