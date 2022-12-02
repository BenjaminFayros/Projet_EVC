using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PressurePlateCollision : MonoBehaviour
{

    public bool isTriggered = false;

    
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "cube")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Pressed");
            isTriggered = true;
        }
        
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("No longer pressed");
            isTriggered = false;
        }
    }
}


