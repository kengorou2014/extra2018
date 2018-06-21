using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureController : MonoBehaviour {

	IndexCollision indexcollision;
	bool flag;

	// Use this for initialization
	void Start () {

//		indexcollision = GameObject.Find ("index").GetComponents<IndexCollision>();
//		flag = indexcollision.isIndexTouch;
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (flag);
	}
}
