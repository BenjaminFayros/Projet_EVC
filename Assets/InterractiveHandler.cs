using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Photon.Pun;

namespace WasaaMP{
public class InterractiveHandler : Interactive
{
    [Header("References")]
    [SerializeField] public HandleData handleInfo;

    public GameObject parent;
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 scale;
    public string handleName;
    private int count;
    private int handleCountMax;
    private bool handleMemory = false;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
        rotation = transform.localRotation;
        scale = transform.localScale;
        handleCountMax = handleInfo.numberHandle-1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (handleName){
            case "topHandle":
                if (base.caught) {handleInfo.topHandle=true;}
                else if (!base.caught) {handleInfo.topHandle=false;}
                break;
            case "bottomHandle":
                if (base.caught) {handleInfo.bottomHandle=true;}
                else if (!base.caught) {handleInfo.bottomHandle=false;}
                break;
            case "leftHandle":
                if (base.caught) {handleInfo.leftHandle=true;}
                else if (!base.caught) {handleInfo.leftHandle=false;}
                break;
            case "rightHandle":
                if (base.caught) {handleInfo.rightHandle=true;}
                else if (!base.caught) {handleInfo.rightHandle=false;}
                break;
            case "frontHandle":
                if (base.caught) {handleInfo.frontHandle=true;}
                else if (!base.caught) {handleInfo.frontHandle=false;}
                break;
            case "backHandle":
                if (base.caught) {handleInfo.backHandle=true;}
                else if (!base.caught) {handleInfo.backHandle=false;}
                break;
        }

        handleInfo.countHandle();

        if ((!handleMemory) && (handleInfo.canMove)){
            handleMemory = true;
        }
        if ((handleMemory) && (!handleInfo.canMove)){
            handleMemory = false;
            RemiseEnPlace();
        }
    }

    [PunRPC] public override void ShowCaught () {
        if ((!base.caught) ) { 
            caught = true ;
            var rb = parent.GetComponent <Rigidbody> () ;
            Debug.Log(rb);
            rb.isKinematic = true ;
            Renderer renderer = GetComponentInChildren <Renderer> () ;
            base.oldColor = renderer.material.color ;
            renderer.material.color = Color.yellow ;
        }
    }

    [PunRPC] public override void ShowReleased () {
        if (base.caught) {
            var rb = parent.GetComponent <Rigidbody> () ;
            Debug.Log(rb);
            rb.isKinematic = false ;
            Renderer renderer = GetComponentInChildren <Renderer> () ;
            renderer.material.color = oldColor ;
            caught = false ;
            RemiseEnPlace();
        }
    }

    private void RemiseEnPlace(){
        // Debug.Log("coucou "+ handleName);
        transform.localPosition = position ;
        transform.localRotation = rotation ;
        transform.localScale = scale ;
    }
}
}
