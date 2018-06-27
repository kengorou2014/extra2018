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
		}

        for (int i = 0; i < PalmObjects.Length; i++)
        {
            var leapPalm = frame.Hands[i];
            var unityPalm = PalmObjects[i];
			if (isForest) {
				SetVisible (unityPalm, green_flag);
				if (leapPalm.IsValid && green_flag) {
					
					Vector normalizedPosition = leapPalm.PalmPosition;
					Vector normalizedDirection = leapPalm.Direction;
					
					normalizedPosition.z = -normalizedPosition.z;
					
					unityPalm.transform.localPosition = ToVector3 (normalizedPosition);
					unityPalm.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
				}

			} else if (isMachine) {
				SetVisible (unityPalm, metal_flag);
				if (leapPalm.IsValid && metal_flag) {

					Vector normalizedPosition = leapPalm.PalmPosition;
					Vector normalizedDirection = leapPalm.Direction;

					normalizedPosition.z = -normalizedPosition.z;

					unityPalm.transform.localPosition = ToVector3 (normalizedPosition);
					unityPalm.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
				}
			}
        }
    }

    void SetVisible(GameObject obj, bool visible)
    {
        foreach (Renderer component in obj.GetComponents<Renderer>())
        {
            component.enabled = visible;
        }
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}
