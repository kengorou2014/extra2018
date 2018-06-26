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
	public bool isForest;
	public bool isMachine;

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
		}

		for (int i = 0; i < FingerObjects.Length; i++)
		{
			var leapFinger = frame.Fingers[i];
			var unityFinger = FingerObjects[i];
//			var fingerName = unityFinger.name;
			var prefabName = "Finger" + (i+1).ToString();
			if (isForest) {
				SetVisible (unityFinger, green_flag);
				if (leapFinger.IsValid && green_flag) {
					Vector normalizedPosition = leapFinger.TipPosition;
					Vector normalizedDirection = leapFinger.Direction;

					normalizedPosition.z = -normalizedPosition.z;
					unityFinger.transform.localPosition = ToVector3 (normalizedPosition);
					unityFinger.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
				}
			} else if (isMachine) {
				SetVisible (unityFinger, metal_flag);
				if (leapFinger.IsValid && metal_flag && isMachine) {
					Vector normalizedPosition = leapFinger.TipPosition;
					Vector normalizedDirection = leapFinger.Direction;
					
					normalizedPosition.z = -normalizedPosition.z;
					unityFinger.transform.localPosition = ToVector3 (normalizedPosition);
					unityFinger.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
				}
			}
		}


	}

	void SetVisible(GameObject obj, bool visible)
	{
		foreach (MeshRenderer component in obj.GetComponents<MeshRenderer>())
		{
			component.enabled = visible;
		}
	}

	Vector3 ToVector3(Vector v)
	{
		return new UnityEngine.Vector3(v.x, v.y, v.z);
	}
}
