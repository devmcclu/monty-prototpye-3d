using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public Light targetLight1;
    public Light targetLight2;
    public Animator doorAnim;
    public Animator levelDoorAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        //targetLight1.color = Color.green;
        //targetLight2.color = Color.green;

        //doorAnim.enabled = true;
        //levelDoorAnim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Help");
        if (other.gameObject.CompareTag("Gummy"))
        {
            if(other.gameObject.GetComponent<GummyFollow>().followPlayer == false)
            {
                targetLight1.color = Color.green;
                targetLight2.color = Color.green;

                doorAnim.enabled = true;
                levelDoorAnim.enabled = true;
            }

        }
    }

}
