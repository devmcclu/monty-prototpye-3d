using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public Light targetLight1;
    public Light targetLight2;
    public Animator doorAnim;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gummy"))
        {

            targetLight1.color = Color.green;
            targetLight2.color = Color.green;

            doorAnim.enabled = true;

        }
    }

}
