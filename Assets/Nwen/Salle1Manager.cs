using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle1Manager : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button1.GetComponent<ButtonScript>().isTriggered && button2.GetComponent<ButtonScript>().isTriggered)
        {
            wall.SetActive(false);
        }
    }
}
