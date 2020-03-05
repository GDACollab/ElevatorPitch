using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public bool moveLeft = false;
    int direction;
    bool opening;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(moveLeft)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        opening = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //While opening = true
            //position += speed * direction
            //if position = 20 * direction
                //stop moving
        //while closing = true
            //position -= speed * direction
            //if position = 8 * direction
                //stop moving
    }

    //Need something that gets info from the timer

        //if timer = max
            //open doors
        //if timer = 0
            //close doors
}
