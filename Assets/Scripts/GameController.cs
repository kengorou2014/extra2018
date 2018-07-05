using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject InitialPlane;
	ChildColliderEnter collider;
	ResultController resultcontroller;
	SequenceController seqcontroller;
	public GameObject InteractionObject;
	public GameObject world;
	private GameObject hand;
	private int waittime;
//	Explosion

	// Use this for initialization
	void Start () {
		seqcontroller = InteractionObject.GetComponent<SequenceController> ();
		resultcontroller = world.GetComponent<ResultController> ();
	}
	
	// Update is called once per frame
	void Update () {
		hand = GameObject.Find ("RigidRoundHand(Clone)");
		if (hand) {
			InitialPlane.SetActive (false);
		} else {
			waittime += 1;
		}

		if (waittime >= 100 || Input.GetKey (KeyCode.Space)) {
			DoInitialize ();
		}
	}



	void DoInitialize() {
		Debug.Log ("doinitialize!!!");
		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();
		collider.Initialize ();
		seqcontroller.Initialize ();
		resultcontroller.Initialize ();
		InitialPlane.SetActive (true);
		seqcontroller = InteractionObject.GetComponent<SequenceController> ();
		resultcontroller = world.GetComponent<ResultController> ();

		waittime = 0;
	}
}
