using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle2Manager : MonoBehaviour
{
    public GameObject buttonL;
    public GameObject buttonR;
    public GameObject barrier;
    private bool success = false;

    // Update is called once per frame
    void Update()
    {
        if (buttonR.GetComponent<ButtonScript>().isTriggered && buttonL.GetComponent<ButtonScript>().isTriggered)
        {
            barrier.SetActive(false);
        }
    }
}
