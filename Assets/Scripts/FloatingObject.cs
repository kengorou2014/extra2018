//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class FloatingObject : MonoBehaviour {
//
////	public GameObject gameObject;
//	public float amplitude = 1.0f; // 振幅
////	public int offset = 200;
//	public float speed;
//	private int frameCnt = 0; // フレームカウント
//	void FixedUpdate () {
//		frameCnt += 1;
//		if( 10000 <= frameCnt ){
//			frameCnt = 0;
//		}
//		if( 0 == frameCnt%2 ){
//			// 上下に振動させる（ふわふわを表現）
////			float posx = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % offset)/(200.0f-1.0f));
//			float posx = transform.position.x;
//			float posy = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % 200)/(200.0f-1.0f));
////			float posz = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt % offset)/(200.0f-1.0f));
//			float posz = transform.position.z;
//			transform.position = new Vector3(posx, posy, posz);
////			iTween.MoveAdd(gameObject,new Vector3(0, amplitude * posYSin, 0),0.0f);
//		}
//	}
//}
//
