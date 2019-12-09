using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotTrigger : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        //If a gummy hits the slingshot
        if(other.gameObject.CompareTag("Gummy"))
        {
            GummyFollow gummy = other.GetComponent<GummyFollow>();
            //If the gummy isn't following the player
            if(gummy.followPlayer == false)
            {
                Debug.Log("GUMMY HIT");
                gummy.stop = true;
                //Shoot the gummy using physics
                Rigidbody gummyRb = gummy.GetComponent<Rigidbody>();
                gummyRb.isKinematic = false;
                gummyRb.AddForce(new Vector3(0, 250, 250));
                //gummies.Add(gummy);
            }
        }
    }
}
