using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollider : MonoBehaviour
{
    public List<GummyFollow> gummies;
    public GameObject gummyItem;

    public int gummiesNeeded = 3;
    void Update()
    {
        if(gummies.Count >= gummiesNeeded)
        {
            for(int i = 0; i < gummiesNeeded; i++)
            {
                GummyFollow currentGummy = gummies[0];
                gummies.RemoveAt(0);
                Destroy(currentGummy.gameObject);
            }

            Instantiate(gummyItem, this.transform.position, gummyItem.transform.rotation);
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
