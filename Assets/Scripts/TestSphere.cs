using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class TestSphere : MonoBehaviour {

	public GameObject sphere;
	public const int NUM_FINGERS = 5;
	public FingerModel[] fingers = new FingerModel[NUM_FINGERS];
	protected Hand hand_;
	protected HandController controller_;
	protected bool mirror_z_axis_ = false;


	public Vector3 GetHandOffset() {
		if (controller_ == null || hand_ == null)
			return Vector3.zero;

		Vector3 additional_movement = controller_.handMovementScale - Vector3.one;
		Vector3 scaled_wrist_position = Vector3.Scale(additional_movement, hand_.WristPosition.ToUnityScaled(mirror_z_axis_));

		return controller_.transform.TransformPoint(scaled_wrist_position) -
			controller_.transform.position;
	}

	// Use this for initialization
	void Start () {
		Debug.Log("start");
		for (int i = 0; i < fingers.Length; ++i) {
			if (fingers[i] != null) {
				fingers[i].SetLeapHand(hand_);
				fingers[i].SetOffset(GetHandOffset());
			}
		}
	}

	// Update is called once per frame

	void Update () {
		
		if (fingers [2] != null) {

		}

		for (int i = 0; i < fingers.Length; ++i) {
//			ここまでiきてる

			if (fingers[i] != null) {
//				ここからiきてない
				Debug.Log (i);
				
				fingers[i].fingerType = (Finger.FingerType)i;


				if (fingers[i].fingerType.ToString() == "TYPE_MIDDLE") {
					
					
//										Debug.Log("fingers[i]: " + fingers[i]);
					//					Debug.Log("fingers[i].fingerType: " + fingers[i].fingerType);
					//					Debug.Log("palm.position: " + GetPalmPosition());
//					Debug.Log("tip.position: " + fingers[i].GetTipPosition());
//					sphere.transform.position =  fingers[i].GetTipPosition ();
//					sphere.transform.position = Vector3.zero;
					//					Debug.Log ("testSphere: " + testSphere.name);
				}
			}
		}
	}
}
