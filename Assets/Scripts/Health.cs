using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int startingHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void HealthDamage(int amount)
    {
        health -= amount;
    }
}
