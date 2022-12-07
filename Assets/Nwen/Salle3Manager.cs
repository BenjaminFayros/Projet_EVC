using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle3Manager : MonoBehaviour
{
    public GameObject pressure;
    public GameObject barrier;


    // Update is called once per frame
    void Update()
    {
        if (pressure.GetComponent<PressurePlateCollision>().isTriggered)
        {
            barrier.SetActive(false);
        }
    }
}