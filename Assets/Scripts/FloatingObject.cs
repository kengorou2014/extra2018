using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {

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
			// 上下に振動させる（ふわふわを表現）
			//			float posx = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % offset)/(200.0f-1.0f));
			float posx = transform.position.x;
			float posy = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 200)/(200.0f-1.0f));
			//			float posz = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % offset)/(200.0f-1.0f));
			float posz = transform.position.z;
			transform.position = new Vector3(posx, defaultY + posy*amplitude, posz);
			//			iTween.MoveAdd(gameObject,new Vector3(0, amplitude * posYSin, 0),0.0f);
		}
	}
}

