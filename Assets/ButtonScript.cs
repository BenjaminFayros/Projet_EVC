using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isTriggered;
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "cursor")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Pressed");
            isTriggered = true;
        }
        
    }
    void OnCollisionExit(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "cursor")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("No longer pressed");
            isTriggered = false;
        }
    }
}
