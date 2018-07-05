using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class LeapFinger : MonoBehaviour
{

	Controller controller = new Controller();

	public int FingerCount;
	public GameObject[] FingerObjects;
	ChildColliderEnter collider;
	private int flag = 0;
	bool green_flag;
	bool metal_flag;
	bool animal_flag;
	bool cyber_flag;
	public bool isForest;
	public bool isMachine;
	public bool isAnimal;
	public bool isCyber;

	bool HandExists;

	void Start()
	{

	}

	void Update()
	{
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();

		if (collider) {
			flag = collider.isTouching ();
			green_flag = collider.TouchedGreen();
			metal_flag = collider.TouchedMetal();
			animal_flag = collider.TouchedAnimal ();
			cyber_flag = collider.TouchedCyber ();

		}
		for (int i = 0; i < FingerObjects.Length; i++)
		{
			var leapFinger = frame.Fingers[i];
			var unityFinger = FingerObjects[i];
			if (isForest) {
				SetInteractionObject (isForest, green_flag, leapFinger, unityFinger);
			} else if (isMachine) {
				SetInteractionObject (isMachine, metal_flag, leapFinger, unityFinger);
			} else if (isAnimal) {
				SetInteractionObject (isAnimal, animal_flag, leapFinger, unityFinger);
			} else if (isCyber) {
				SetInteractionObject (isCyber, cyber_flag, leapFinger, unityFinger);
			}
		}
	}

	void SetInteractionObject(bool typeOfObject, bool objectFlag, Finger leapFinger, GameObject unityFinger){
		SetVisible (unityFinger, objectFlag);
		if (leapFinger.IsValid && objectFlag) {
			Vector normalizedPosition = leapFinger.TipPosition;
			Vector normalizedDirection = leapFinger.Direction;

			normalizedPosition.z = -normalizedPosition.z;
			unityFinger.transform.localPosition = ToVector3 (normalizedPosition);
			unityFinger.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
		}
	}

	void SetVisible(GameObject obj, bool visible)
	{
		if (visible) {
			obj.SetActive (true);
			HandExists = true;
//			gameObject.SetActive (true);
		} else {
			obj.SetActive (false);
			HandExists = false;
//			gameObject.SetActive (false);
		}
	}

	Vector3 ToVector3(Vector v)
	{
		return new UnityEngine.Vector3(v.x, v.y, v.z);
	}

	public bool HandExist(){
		return HandExists;
	}
}
