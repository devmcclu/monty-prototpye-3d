using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollider : MonoBehaviour
{
    //Gummies in area
    public List<GummyFollow> gummies;
    //Item to be spawned when enough gummies are there
    public GameObject gummyItem;
    //Gummies required to make the item
    public int gummiesNeeded = 3;
    public Transform spawnPoint;
    
    void Update()
    {
        //If enough gummies are in the area
        if(gummies.Count >= gummiesNeeded)
        {
            //Go through the gummies needed, remove them from the list, and destroy them
            for(int i = 0; i < gummiesNeeded; i++)
            {
                GummyFollow currentGummy = gummies[0];
                gummies.RemoveAt(0);
                Destroy(currentGummy.gameObject);
            }
            //Make the item
            Instantiate(gummyItem, spawnPoint.position, gummyItem.transform.rotation);
            //Destroy the collider area
            Destroy(this.gameObject);
        }
    }

    //Stop a Gummy from moving once it enters the area
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
