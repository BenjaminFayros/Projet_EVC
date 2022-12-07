using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle1Manager : MonoBehaviour
{
    public GameObject pressureL;
    public GameObject pressureR;
    public GameObject glassDoorR;
    public GameObject glassDoorL;
    public GameObject barrier;
    private bool success = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pressureR.GetComponent<PressurePlateCollision>().isTriggered && pressureL.GetComponent<PressurePlateCollision>().isTriggered)
        {
            barrier.SetActive(false);
            success = true;
        }
        if (pressureR.GetComponent<PressurePlateCollision>().isTriggered)
        {
            glassDoorR.SetActive(true);
        } 
        else if(!success)
        {
            glassDoorR.SetActive(false);
        }
        if (pressureL.GetComponent<PressurePlateCollision>().isTriggered)
        {
            glassDoorL.SetActive(true);
        }
        else if(!success)
        {
            glassDoorL.SetActive(false);
        }
    }
}
