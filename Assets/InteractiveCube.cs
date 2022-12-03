using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Photon.Pun;

namespace WasaaMP{
public class InteractiveCube : Interactive
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC] public override void ShowCaught () {
        if (! base.caught) {
            var rb = GetComponent<Rigidbody> () ;
            rb.isKinematic = true ;
            Renderer renderer = GetComponentInChildren <Renderer> () ;
            base.oldColor = renderer.material.color ;
            renderer.material.color = Color.yellow ;
            base.caught = true ;
        }
    }

    [PunRPC] public override void ShowReleased () {
        if (base.caught) {
            var rb = GetComponent<Rigidbody> () ;
            rb.isKinematic = false ;
            Renderer renderer = GetComponentInChildren <Renderer> () ;
            renderer.material.color = oldColor ;
            base.caught = false ;
        }
    }
}
}
