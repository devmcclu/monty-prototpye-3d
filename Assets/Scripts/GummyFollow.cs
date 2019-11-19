using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyFollow : MonoBehaviour
{
    public Transform leader;
    //public float followSharpness = 0.1f;
    //Vector3 _followOffset;
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //_followOffset = transform.position - leader.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != leader.position)
            transform.position = Vector3.MoveTowards(transform.position, leader.position, speed);
    }
    
    void FixedUpdate()
    {
        // Apply that offset to get a target position.
        //Vector3 targetPosition = leader.position + _followOffset;

        // Keep our y position unchanged.
        //targetPosition.y = transform.position.y;

        // Smooth follow.    
        //transform.position += (targetPosition - transform.position) * followSharpness;
    }
}
