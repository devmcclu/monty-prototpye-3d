using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GetComponent<GummyFollow>().player.gameObject)
        {
            GetComponent<GummyFollow>().AddGummy();
        }
    }
}
