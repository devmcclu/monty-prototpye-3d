using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float timer;
    public List<GummyFollow> gummies;
    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (gummies.Count > 0)
            {
                for (int i = 0; i < gummies.Count; i++)
                {
                    this.GetComponent<Health>().HealthDamage(10);
                }
            }
            timer = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        if(other.gameObject.CompareTag("Gummy"))
        {
            GummyFollow gummy = other.GetComponent<GummyFollow>();
            if(gummy.followPlayer == false && !gummies.Contains(gummy))
            {
                Debug.Log("GUMMY HIT");
                gummy.stop = true;
                gummies.Add(gummy);
            }
        }
    }
}
