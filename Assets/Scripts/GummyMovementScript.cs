using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyMovementScript : MonoBehaviour
{
    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirZ = speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dirZ);

    }
}
