using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{


    public Light testLight;
    public float minWaitTime;
    public float maxWaitTime;

    void Start()
    {
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            testLight.enabled = !testLight.enabled;

        }
    }
}
