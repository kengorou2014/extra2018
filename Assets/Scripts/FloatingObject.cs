using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {


	private float speed = 10f;
	private float amplitude = 0.2f;
	private int frameCnt = 0; // フレームカウント
	private float defaultY;
	public int flagNumber;
	ChildColliderEnter collider;
	List<int> seq = new List<int> ();

	void Start(){
		defaultY = transform.position.y;

	}


	void FixedUpdate () {
		
		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();
		if (collider) {
			seq = collider.touchSequence ();
		}
		if (seq.Exists (x => x == flagNumber)){
			FloatObject ();
		}


	}

	void FloatObject(){
		frameCnt += 1;
		if( 10000 <= frameCnt ){
			frameCnt = 0;
		}
		if( 0 == frameCnt%2 ){
			float posx = transform.position.x;
			float posy = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 200)/(200.0f-1.0f));
			float posz = transform.position.z;
			transform.position = new Vector3(posx, defaultY + posy*amplitude, posz);

			float rotx = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 200)/(200.0f-1.0f));
			float roty = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 400)/(200.0f-1.0f));
			float rotz = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 100)/(200.0f-1.0f));

			transform.Rotate(rotx, roty, rotz);
		}
	}
}

