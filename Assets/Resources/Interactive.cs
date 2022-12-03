using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace WasaaMP {
    public class Interactive : MonoBehaviourPun {

        private Color colorBeforeHighlight ;
        protected Color oldColor ;
        private float oldAlpha ;

        protected bool catchable = false ;
        protected bool caught = false ;
        void Start () {
            
        }

        void Update () {
            
        }

        [PunRPC] public virtual void ShowCaught () {
            // if (! caught) {
            //     var rb = GetComponent<Rigidbody> () ;
            //     rb.isKinematic = true ;
            //     Renderer renderer = GetComponentInChildren <Renderer> () ;
            //     base.oldColor = renderer.material.color ;
            //     renderer.material.color = Color.yellow ;
            //     caught = true ;
            // }
        }

        [PunRPC] public virtual void ShowReleased () {
            // if (caught) {
            //     var rb = GetComponent<Rigidbody> () ;
            //     rb.isKinematic = false ;
            //     Renderer renderer = GetComponentInChildren <Renderer> () ;
            //     renderer.material.color = oldColor ;
            //     caught = false ;
            // }
        }

        [PunRPC] public void ShowCatchable () {
            if (! caught) {
                if (! catchable) {
                    Renderer renderer = GetComponentInChildren <Renderer> () ;
                    oldAlpha = renderer.material.color.a ;
                    colorBeforeHighlight = renderer.material.color ;
                    //Color c = renderer.material.color ;
                    Color c = Color.cyan ;
                    renderer.material.color = new Color (c.r, c.g, c.b, 0.5f) ;
                    catchable = true ;
                }
            }
        }
        
        [PunRPC] public void HideCatchable () {
            if (! caught) {
                if (catchable) {
                    Renderer renderer = GetComponentInChildren <Renderer> () ;
                    //Color c = renderer.material.color ;
                    Color c = colorBeforeHighlight ;
                    renderer.material.color = new Color (c.r, c.g, c.b, oldAlpha) ;
                    catchable = false ;
                }
            }
        }

    }
    
}
