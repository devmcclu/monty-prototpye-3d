using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public Transform player;

    //public float distanceFromObject = 6f;

    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 lookOnObject = player.position - transform.position;
        // transform.forward = lookOnObject.normalized;

        // Vector3 playerLastPosition = player.position - lookOnObject.normalized * distanceFromObject;
        // transform.position = playerLastPosition;

        // playerLastPosition.y = player.position.y + distanceFromObject/2;
        // transform.position = playerLastPosition;      
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);
 
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
         
        transform.LookAt(target.transform);
    }
}
