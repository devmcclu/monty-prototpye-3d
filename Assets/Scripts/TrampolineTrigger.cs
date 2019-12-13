using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What this?");
        //If a gummy hits the slingshot
        if(other.gameObject.CompareTag("Player"))
        {
            CharacterController playerRb = other.GetComponent<CharacterController>();
            playerRb.Move(new Vector3(0, 15, 0));

        }
    }
}
