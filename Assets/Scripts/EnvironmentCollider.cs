using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollider : MonoBehaviour
{
    public List<GummyFollow> gummies;
    public GameObject ladder;
    void Update()
    {
        if(gummies.Count >= 3)
        {
            for(int i = 0; i < 3; i++)
            {
                GummyFollow currentGummy = gummies[0];
                gummies.RemoveAt(0);
                Destroy(currentGummy.gameObject);
            }

            Instantiate(ladder);
        }
    }

    //Stop a Gummy from moving once it enters the area
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        if(other.gameObject.CompareTag("Gummy"))
        {
            Debug.Log("GUMMY HIT");
            other.GetComponent<GummyFollow>().stop = true;
            gummies.Add(other.GetComponent<GummyFollow>());
        }
    }
}
