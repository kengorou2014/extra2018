using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderEnter: MonoBehaviour {

	GameObject parent;
	public static bool flag;

	void Start () {
		parent = gameObject.transform.parent.gameObject;
	}

	void OnTriggerStay(Collider other) {
//		parent.SendMessage("RedirectedOnCollisionEnter", other);
		Debug.Log ("トリガーエンター" + other.gameObject.name);
		flag = true;
	}

	void OnTriggerExit(Collider other) {
//		parent.SendMessage("RedirectedOnCollisionExit", other);
		Debug.Log ("トリガーイグジット" + other.gameObject.name);
		flag = false;
	}

	void Update(){
		Debug.Log (flag);
	}
}
