using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyFollow : MonoBehaviour
{
    //Where the gummy should follow
    public Transform followPosition;
    public PlayerController player;
    //Speed of the gummy
    public float speed = 1f;
    //How far away the gummy can be from the follow point
    public float maxDistance = 10f;
    //should it follow the player?
    public bool followPlayer = true;
    //Is it stopped?
    public bool stop = false;
    public Vector3 playerForward;
    
    // Start is called before the first frame update
    void Start()
    {
        //Add the Gummy to the player's list of followers
        player = FindObjectOfType<PlayerController>();
        //player.followers.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        //If the gummy is allowed to follow the player and is not
        //At the follow position
        if(followPosition != null)
        {
            if(transform.position != followPosition.position && followPlayer == true)
            {
                //Move to the follow position
                transform.position = Vector3.MoveTowards(transform.position, followPosition.position, speed);
            }
            //If told to move somewhere and not at the stop point
            else if (followPlayer == false && stop == false)
            {
                speed = 10;
                float dirZ = speed * Time.deltaTime;
                //Walk forawrd
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dirZ);
                transform.position += playerForward * speed * Time.deltaTime;
                //Once reached max distance, go back to player
                if(Vector3.Distance(transform.position, followPosition.position) > maxDistance)
                {
                    speed = 1;
                    AddGummy();
                    followPlayer = true;
                }
            }
        }
    }

    public void AddGummy()
    {
        player.followers.Add(this);
        followPosition = player.followPoint;
    }
}
