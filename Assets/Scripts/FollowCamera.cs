using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //creating a reference: 
        //if we want to access/change/call anything other than THIS game object's transform, we need to a create a reference
        //have to tell unity what the THING is we're referrring to

    [SerializeField] GameObject thingToFollow;


    //this thing's position, should be the same as the car's position

     void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
