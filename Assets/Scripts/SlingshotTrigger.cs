using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        if(other.gameObject.CompareTag("Gummy"))
        {
            GummyFollow gummy = other.GetComponent<GummyFollow>();
            if(gummy.followPlayer == false)
            {
                Debug.Log("GUMMY HIT");
                gummy.stop = true;
                Rigidbody gummyRb = gummy.GetComponent<Rigidbody>();
                gummyRb.isKinematic = false;
                gummyRb.AddForce(new Vector3(0, 250, 250));
                //gummies.Add(gummy);
            }
        }
    }
}
