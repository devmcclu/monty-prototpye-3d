using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float turnSpeedMultiplier;
    public float turnSpeed = 10f;

    private CharacterController characterController;
    private Vector3 targetDirection;
    private Vector2 input;
    private Quaternion freeRotation;
    private Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        input.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterController.SimpleMove(targetDirection * speed);
        // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
        UpdateTargetDirection();
        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            var eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
            var euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        }
        
    }

    public virtual void UpdateTargetDirection()
    {
        turnSpeedMultiplier = 1f;
        var forward = mainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;

        //get the right-facing direction of the referenceTransform
        var right = mainCamera.transform.TransformDirection(Vector3.right);

        // determine the direction the player will face based on input and the referenceTransform's right and forward directions
        targetDirection = input.x * right + input.y * forward;
    }
}
