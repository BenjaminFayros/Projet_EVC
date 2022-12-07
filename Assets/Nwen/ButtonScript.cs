using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isTriggered;
    private Renderer buttonRenderer;
    //Detect collisions between the GameObjects with Colliders attached
    void Start()
    {
        buttonRenderer = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        if(isTriggered)
        {
            buttonRenderer.material.color = Color.green;
        }
        else
        {
            buttonRenderer.material.color = Color.red;
        }
    }
}
