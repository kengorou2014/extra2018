using UnityEngine;
using System.Collections;
using Leap;

public class LeapPalm : MonoBehaviour
{

    Controller controller = new Controller();

    public int PalmCount;
    public GameObject[] PalmObjects;
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
	public bool doOrbit;
	public float orbitSpeed;

    void Start()
    {
    }

    void Update()
    {
        Frame frame = controller.Frame();
        PalmCount = frame.Fingers.Count;
		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();
		if (collider) {
			flag = collider.isTouching ();
			green_flag = collider.TouchedGreen();
			metal_flag = collider.TouchedMetal();
			animal_flag = collider.TouchedAnimal();
			cyber_flag = collider.TouchedCyber();
		}
			
        var leapPalm = frame.Hands[0];
        var unityPalm = PalmObjects[0];
		if (isForest) {
			SetInteractionObject (isForest, green_flag, leapPalm, unityPalm);
		} else if (isMachine) {
			SetInteractionObject (isForest, metal_flag, leapPalm, unityPalm);
		} else if (isAnimal) {
			SetInteractionObject (isForest, animal_flag, leapPalm, unityPalm);
		} else if (isCyber) {
			if (doOrbit) {
				SetInteractionOrbitObject (isForest, cyber_flag, leapPalm, unityPalm);
			} else {
				SetInteractionObject (isForest, cyber_flag, leapPalm, unityPalm);
			}
		}
    }

	void SetInteractionObject(bool typeOfObject, bool objectFlag, Hand leapPalm, GameObject unityPalm){
		SetVisible (unityPalm, objectFlag);
		if (leapPalm.IsValid && objectFlag) {
			Vector normalizedPosition = leapPalm.PalmPosition;
			Vector normalizedDirection = leapPalm.Direction;

			normalizedPosition.z = -normalizedPosition.z;
			unityPalm.transform.localPosition = ToVector3 (normalizedPosition);
			unityPalm.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
		}
	}

	void SetInteractionOrbitObject(bool typeOfObject, bool objectFlag, Hand leapPalm, GameObject unityPalm){
		SetVisible (unityPalm, objectFlag);
		if (leapPalm.IsValid && objectFlag)
		{
			Vector normalizedPosition = leapPalm.PalmPosition;
			Vector offset = new Vector(2, 1, 2);
			Vector axis = normalizedPosition + offset;

			unityPalm.transform.localPosition = ToVector3(normalizedPosition);
			transform.RotateAround(ToVector3(axis), ToVector3(normalizedPosition), orbitSpeed * Time.deltaTime);

		}
	}

	void SetVisible(GameObject obj, bool visible)
	{
		if (visible) {
			obj.SetActive (true);
		} else {
			obj.SetActive (false);
		}
	}

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}
