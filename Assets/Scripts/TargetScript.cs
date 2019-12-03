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
        StartCoroutine("DelayStart");
        //targetLight1.color = Color.green;
        //targetLight2.color = Color.green;

        //doorAnim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigerr");
        if (other.gameObject.CompareTag("slingshot"))
        {

            targetLight1.color = Color.green;
            targetLight2.color = Color.green;

            doorAnim.enabled = true;

        }
    }

    IEnumerator DelayStart() {

        yield return new WaitForSeconds(3);

        targetLight1.color = Color.green;
        targetLight2.color = Color.green;

        doorAnim.enabled = true;
    }

}
