using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PressurePlateCollision : MonoBehaviour
{

    public bool isTriggered = false;
    public string targetTag = "cube";
    private Color oldColor;
    private Renderer plateRenderer;

    private void Start()
    {
        plateRenderer = gameObject.GetComponent<Renderer>();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == targetTag)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Pressed");
            oldColor = plateRenderer.material.color;
            plateRenderer.material.color = Color.green;
            isTriggered = true;
        }
        
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("No longer pressed");
            plateRenderer.material.color = oldColor;
            isTriggered = false;
        }
    }
}


