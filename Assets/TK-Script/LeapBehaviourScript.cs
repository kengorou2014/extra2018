//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Leap;

//public class LeapBehaviourScript : MonoBehaviour
//{

//    Controller controller = new Controller();

//    public int FingerCount;
//    public GameObject[] FingerObjects;
//	ChildColliderEnter collider;
//	private int flag = 0;
//	bool green_flag;
//	bool metal_flag;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        Frame frame = controller.Frame();
//        FingerCount = frame.Fingers.Count;
//		collider = GameObject.Find ("RigidRoundHand/index/bone3").GetComponent<ChildColliderEnter>();
//		if (collider) {
//<<<<<<< HEAD
//			//flag = collider.isTouching ();
//			permanent_flag  = collider.permanentFlag();
//=======
//			flag = collider.isTouching ();
//			green_flag = collider.TouchedGreen();
//			metal_flag = collider.TouchedMetal();
//>>>>>>> 37154e48f81041176bdc772ac02743bdb176b0a8
//		}
			

//        for (int i = 0; i < FingerObjects.Length; i++)
//        {
//            var leapFinger = frame.Fingers[i];
//            var unityFinger = FingerObjects[i];
//            SetVisible(unityFinger, leapFinger.IsValid);
//			if (leapFinger.IsValid && metal_flag && unityFinger.name == "Finger5") {
				
//				Vector normalizedPosition = leapFinger.TipPosition;
//				Vector normalizedDirection = leapFinger.Direction;

//				normalizedPosition.z = -normalizedPosition.z;
//				unityFinger.transform.localPosition = ToVector3 (normalizedPosition);
//				unityFinger.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));

//			} else if (leapFinger.IsValid && green_flag && unityFinger.name == "Finger1") {

//				Vector normalizedPosition = leapFinger.TipPosition;
//				Vector normalizedDirection = leapFinger.Direction;

//				normalizedPosition.z = -normalizedPosition.z;
//				unityFinger.transform.localPosition = ToVector3 (normalizedPosition);
//				unityFinger.transform.localRotation = Quaternion.Euler (ToVector3 (normalizedDirection * 100));
//			}
//        }


//    }

//    void SetVisible(GameObject obj, bool visible)
//    {
//        foreach (Renderer component in obj.GetComponents<Renderer>())
//        {
//            component.enabled = visible;
//        }
//    }

//    Vector3 ToVector3(Vector v)
//    {
//        return new UnityEngine.Vector3(v.x, v.y, v.z);
//    }
//}
