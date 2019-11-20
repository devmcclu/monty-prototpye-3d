using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollider : MonoBehaviour
{
    //Stop a Gummy from moving once it enters the area
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        if(other.gameObject.CompareTag("Gummy"))
        {
            Debug.Log("GUMMY HIT");
            other.GetComponent<GummyFollow>().stop = true;
        }
    }
}
