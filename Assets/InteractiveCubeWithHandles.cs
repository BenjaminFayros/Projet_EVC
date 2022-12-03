using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

namespace WasaaMP{
public class InteractiveCubeWithHandles : MonoBehaviourPun
{
    public GameObject topHandle ;
    public GameObject bottomHandle ;
    public GameObject leftHandle ;
    public GameObject rightHandle ;
    public GameObject frontHandle ;
    public GameObject backHandle ;
    
    public HandleData handleInfo ; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (handleInfo.canMove){
            transform.position = (topHandle.transform.position +
                                bottomHandle.transform.position +
                                leftHandle.transform.position +
                                rightHandle.transform.position +
                                frontHandle.transform.position +
                                backHandle.transform.position) / 6 ;
        }
    }
}
}
