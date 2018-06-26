using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class LeapBehaviourScript : MonoBehaviour
{

    Controller controller = new Controller();

    public int FingerCount;
    public GameObject[] FingerObjects;
	public ChildColliderEnter collider;
	private int flag = 0;
	private List<int> permanent_flag = new List<int>();

    void Start()
    {
//		collider = GameObject.Find (ChildColliderEnter);
    }

    void Update()
    {
        Frame frame = controller.Frame();
        FingerCount = frame.Fingers.Count;
		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();
		if (collider) {
			//flag = collider.isTouching ();
			permanent_flag  = collider.permanentFlag();
		}

		//1本目の指
//		if (permanenet_flag.match(1)){
//			var leapFinger_0 = frame.Fingers[0];
//			var unityFinger_0 = FingerObjects[0];
//			SetVisible(unityFinger_0, leapFinger_0.IsValid);
//		}

		//2本目の指
		//3本目の指
		//4本目の指
		//5本目の指

        for (int i = 0; i < FingerObjects.Length; i++)
        {
            var leapFinger = frame.Fingers[i];
            var unityFinger = FingerObjects[i];
            SetVisible(unityFinger, leapFinger.IsValid);
			if (leapFinger.IsValid && permanent_flag.Exists (x => x == i))
            {
				Debug.Log (unityFinger.name);
                Vector normalizedPosition = leapFinger.TipPosition;
                Vector normalizedDirection = leapFinger.Direction;

                normalizedPosition.z = -normalizedPosition.z;
                unityFinger.transform.localPosition = ToVector3(normalizedPosition);
                unityFinger.transform.localRotation = Quaternion.Euler(ToVector3(normalizedDirection*100));

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
