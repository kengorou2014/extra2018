using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexCollision : MonoBehaviour {

	public static bool isIndexTouch;

	void RedirectedOnCollisionEnter (Collider other)
	{
		isIndexTouch = true;
	}

	void RedirectedOnCollisionExit (Collider other)
	{
		isIndexTouch = false;
	}

//	void Update(){
//		Debug.Log (isIndexTouch);
//	}
}
