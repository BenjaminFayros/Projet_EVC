using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle4Manager : MonoBehaviour
{
    public GameObject pressureCarré;
    public GameObject pressureTriangle;
    public GameObject pressureRond;
    public GameObject barrier;


    // Update is called once per frame
    void Update()
    {
        if (pressureCarré.GetComponent<PressurePlateCollision>().isTriggered && pressureTriangle.GetComponent<PressurePlateCollision>().isTriggered && pressureRond.GetComponent<PressurePlateCollision>().isTriggered)
        {
            barrier.SetActive(false);
        }
    }
}
