using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	SequenceController seqcontroller;
	private int flag;

	public GameObject ExploadObj1;
	public GameObject ExploadPos1;
	public float waittime1;
	public GameObject ExploadObj2;
	public GameObject ExploadPos2;
	public float waittime2;
	public GameObject ExploadObj3;
	public GameObject ExploadPos3;
	public float waittime3;
	public GameObject ExploadObj4;
	public GameObject ExploadPos4;
	public float waittime4;


	private bool once = true;
	//	private bool exp2 = true;

	void Start() {
		seqcontroller = GameObject.Find ("InteractionObject").GetComponent<SequenceController>();
	}


	// Update is called once per frame
	void Update () {

		flag = seqcontroller.ResultFlag ();

		if (flag == 2) {
			if (once) {
				Invoke ("Explose1", waittime1);
				Invoke ("Explose2", waittime2);
				Invoke ("Explose3", waittime3);
				Invoke ("Explose4", waittime4);
				once = false;
			}
		}
	}

	void Explose1() {
		Instantiate (ExploadObj1, ExploadPos1.transform.position, Quaternion.identity);
	}

	void Explose2() {
		Instantiate (ExploadObj2, ExploadPos2.transform.position, Quaternion.identity);
	}

	void Explose3() {
		Instantiate (ExploadObj3, ExploadPos3.transform.position, Quaternion.identity);
	}

	void Explose4() {
		Instantiate (ExploadObj4, ExploadPos4.transform.position, Quaternion.identity);
	}
}