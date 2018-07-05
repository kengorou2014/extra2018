using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour {

	SequenceController seqcontroller;
	private int flag;
	public GameObject RotWorld;
	public GameObject GrowWorld;
	public GameObject stage;
	public GameObject machinebox;
	public GameObject forestbox;
	public GameObject animalbox;
	public GameObject cyberbox;
	public GameObject machinelight;
	public GameObject forestlight;
	public GameObject animallight;
	public GameObject cyberlight;
	private Vector3 machinepos;
	private Vector3 forestpos;
	private Vector3 animalpos;
	private Vector3 cyberpos;
//	private

	// Use this for initialization
	void Start () {
		seqcontroller = GameObject.Find ("InteractionObject").GetComponent<SequenceController>();
		machinepos = machinebox.transform.position;
		Debug.Log (machinepos);
		Debug.Log (machinebox.transform.position);
		forestpos = forestbox.transform.position;
		animalpos = animalbox.transform.position;
		cyberpos = cyberbox.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		flag = seqcontroller.ResultFlag ();
		if (flag == 1) {
			GrowWorld.SetActive (true);
			ChangeToChase ();
			stage.SetActive (false);
		} else if (flag == 2) {
			RotWorld.SetActive (true);
			stage.SetActive (false);
		}
	}

	void ChangeToChase(){
//		foreach (GameObject obj in )
		machinebox.GetComponent<FloatingObject>().enabled = false;
		machinebox.GetComponent<FollowHand>().enabled = true;
		machinelight.SetActive (true);

		forestbox.GetComponent<FloatingObject>().enabled = false;
		forestbox.GetComponent<FollowHand>().enabled = true;
		forestlight.SetActive (true);

		animalbox.GetComponent<FloatingObject>().enabled = false;
		animalbox.GetComponent<FollowHand>().enabled = true;
		animallight.SetActive (true);

		cyberbox.GetComponent<FloatingObject>().enabled = false;
		cyberbox.GetComponent<FollowHand>().enabled = true;
		cyberlight.SetActive (true);
	}


	public void Initialize(){
		flag = 0;
		stage.SetActive (true);
		machinebox.GetComponent<FloatingObject>().enabled = true;
		machinebox.GetComponent<FollowHand>().enabled = false;
		machinelight.SetActive (false);
		machinebox.transform.position = machinepos;

		forestbox.GetComponent<FloatingObject>().enabled = true;
		forestbox.GetComponent<FollowHand>().enabled = false;
		forestlight.SetActive (false);
		forestbox.transform.position = forestpos;

		animalbox.GetComponent<FloatingObject>().enabled = true;
		animalbox.GetComponent<FollowHand>().enabled = false;
		animallight.SetActive (false);
		animalbox.transform.position = animalpos;

		cyberbox.GetComponent<FloatingObject>().enabled = true;
		cyberbox.GetComponent<FollowHand>().enabled = false;
		cyberlight.SetActive (false);
		cyberbox.transform.position = cyberpos;
	}
}
