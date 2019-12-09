using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Current health
    public int health;
    //Starting health of the object
    public int startingHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    public void HealthDamage(int amount)
    {
        //Remove the health
        health -= amount;
        //Destroy the object if the health is at or below 0
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
