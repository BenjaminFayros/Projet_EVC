using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCursor : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        print($"BUTTON enter : {collision.gameObject.tag}");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "button")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Button Pressed");
            collision.gameObject.GetComponent<ButtonScript>().isTriggered = !collision.gameObject.GetComponent<ButtonScript>().isTriggered;
        }

    }
    void OnTriggerExit(Collider collision)
    {
        print($"BUTTON exit : {collision.gameObject.tag}");
        if (collision.gameObject.tag == "button")
        {
            //collision.gameObject.GetComponent<ButtonScript>().isTriggered = false;
        }
    }
}
