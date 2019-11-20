using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed of the player
    public float speed = 10f;
    //Turn speed of the camera
    public float turnSpeed = 10f;
    //List of gummies following the player
    public List<GummyFollow> followers;
    //GameObject that the gummies follow    
    public Transform followPoint;

    private float turnSpeedMultiplier;
    private CharacterController characterController;
    private Vector3 targetDirection;
    //Movement input of the player
    private Vector2 input;
    private Quaternion freeRotation;
    private Camera mainCamera;
    private bool fired;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Tell the first gummy following the player to walk forward
        if(Input.GetAxis("Fire1") > 0)
        {
            for(int i = 0; i < followers.Count; i++)
            {
                if (followers[i].followPlayer == true && fired == false)
                {
                    fired = true;
                    followers[i].followPlayer = false;
                    followers[i].playerForward = transform.forward;
                    followers.RemoveAt(i);
                }
                if (fired == true) break;
            }
            fired = false;
        }
    }

    void FixedUpdate()
    {
        //Get the input of the player
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
