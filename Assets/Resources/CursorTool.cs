using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace WasaaMP {
	public class CursorTool : MonoBehaviourPun {
		private bool caught ;
		public Interactive interactiveObjectToInstanciate ;
		public HandleData handleInfo ;
		private Interactive target ;
		private MonoBehaviourPun targetParent ;
		private Transform oldParent = null ;
		private Renderer renderer ;

		void Start () {
			renderer = GetComponentInChildren <Renderer> () ;
            if (photonView.IsMine) {
                caught = false ;
                float red = PlayerPrefs.GetFloat ("Red") ;
                float green = PlayerPrefs.GetFloat ("Green") ;
                float blue = PlayerPrefs.GetFloat ("Blue") ;
                GetComponent<Renderer>().material.color = new Color (red, green, blue) ;
            } else {
                photonView.RPC ("SendMeTheColor", RpcTarget.Others) ;
                PhotonNetwork.SendAllOutgoingCommands () ;
            }
		}
		
		public void Catch () {
			print ("Catch ?") ;
			if (target != null) {
				print ("Catch :") ;
				if ((! caught) && (transform != target.transform) && (target is InteractiveCube)) { // pour ne pas prendre 2 fois l'objet et lui faire perdre son parent
					print ("Catch : InteractiveCube") ;
					oldParent = target.transform.parent ;
					target.transform.SetParent (transform) ;
					// target.photonView.RequestOwnership() ;
					target.photonView.TransferOwnership (PhotonNetwork.LocalPlayer) ;
					target.photonView.RPC ("ShowCaught", RpcTarget.All) ;
					PhotonNetwork.SendAllOutgoingCommands () ;
					caught = true ;
				}
				if ((! caught) && (transform != target.transform) && (target is InterractiveHandler)) { // pour ne pas prendre 2 fois l'objet et lui faire perdre son 
					print ("Catch : InterractiveHandler") ;
					caught = true ;
					target.photonView.RPC ("ShowCaught", RpcTarget.All) ;
					oldParent = target.transform.parent ;
					target.transform.SetParent (transform) ;
					// target.photonView.RequestOwnership() ;
					target.photonView.TransferOwnership (PhotonNetwork.LocalPlayer) ;
					PhotonNetwork.SendAllOutgoingCommands () ;
				}
			} else {
				print ("Catch failed") ;
			}
		}

		public void Release () {
			if (caught) {
				print ("Release :") ;
				target.transform.SetParent (oldParent) ;
				target.photonView.RPC ("ShowReleased", RpcTarget.All) ;
				PhotonNetwork.SendAllOutgoingCommands () ;
				print ("Release !") ;
				caught = false ;
			}
		}

		public void CreateInteractiveCube () {
			var objectToInstanciate = PhotonNetwork.Instantiate (interactiveObjectToInstanciate.name, transform.position, transform.rotation, 0) ;
		}

		void OnTriggerEnter (Collider other) {
			if (! caught) {
				print (name + " : CursorTool OnTriggerEnter") ;
				target = other.gameObject.GetComponent<Interactive> () ;
				if (target != null) {
					target.photonView.RPC ("ShowCatchable", RpcTarget.All) ;
					PhotonNetwork.SendAllOutgoingCommands () ;
				}
			}
		}

		void OnTriggerExit (Collider other) {
			if (! caught) {
				print (name + " : CursorTool OnTriggerExit") ;
				if (target != null) {
					target.photonView.RPC ("HideCatchable", RpcTarget.All) ;
					PhotonNetwork.SendAllOutgoingCommands () ;
					target = null ;
				}
			}
		}

		[PunRPC] void SendMeTheColor (PhotonMessageInfo info) {
            if (photonView.IsMine) {
                var c = renderer.material.color ;
                Vector3 myVector = new Vector3 (c.r, c.g, c.b) ;
                photonView.RPC ("SetTheColor", RpcTarget.All, myVector) ;
                // photonView.RPC ("SetTheColor", info.Sender, myVector) ; à vérifier, serait mieux que la ligne précédente
                PhotonNetwork.SendAllOutgoingCommands () ;
            }
        }

        [PunRPC] void SetTheColor (Vector3 myVector, PhotonMessageInfo info) {
            Color c = new Color (myVector [0], myVector [1], myVector [2]) ;
            renderer.material.color = c ;
        }

	}

}