using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour {

	SequenceController seqcontroller;
	private int flag;
	public GameObject RotWorld;
	public GameObject GrowWorld;
	public GameObject stage;
//	private

	// Use this for initialization
	void Start () {
		seqcontroller = GameObject.Find ("InteractionObject").GetComponent<SequenceController>();
	}
	
	// Update is called once per frame
	void Update () {
		flag = seqcontroller.ResultFlag ();
		if (flag == 1) {
			GrowWorld.SetActive (true);
			stage.SetActive (false);
		} else if (flag == 2) {
			RotWorld.SetActive (true);
			stage.SetActive (false);
		}
	}

//	void TriggerExplosion() {
//		return
//	}
}
