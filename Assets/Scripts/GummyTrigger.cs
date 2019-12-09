using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyTrigger : MonoBehaviour
{
    private GummyFollow followScipt;

    void Start()
    {
        followScipt = GetComponent<GummyFollow>();
    }

    void OnTriggerEnter(Collider other)
    {
        //If the gummy collides with the player and is not in the follower list
        if(other.gameObject == followScipt.player.gameObject &&
            !other.GetComponent<PlayerController>().followers.Contains(followScipt))
            //&& followScipt.followPlayer == true)
        {
            Debug.Log("Help");
            followScipt.AddGummy();
            followScipt.followPlayer = true;
        }
    }
}
