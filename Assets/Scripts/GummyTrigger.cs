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
        if(other.gameObject == followScipt.player.gameObject)
        {
            followScipt.AddGummy();
        }
    }
}
