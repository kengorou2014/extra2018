
using UnityEngine;
using System.Collections;
using Leap;

public class ProtSphere : MonoBehaviour {

	Controller controller = new Controller();

	public int FingerCount;
	public GameObject[] FingerObjects;

	void Start()
	{
	}

	void Update()
	{
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
//		Debug.Log("FingerCount: " + FingerCount);

		InteractionBox interactionBox = frame.InteractionBox;

		for ( int i = 0; i < FingerObjects.Length; i++ ) {
			var leapFinger = frame.Fingers[i];
			var unityFinger = FingerObjects[i];
			Debug.Log("untiyfinger: " + unityFinger);
			SetVisible( unityFinger, leapFinger.IsValid );

			if ( leapFinger.IsValid ) {
				Vector normalizedPosition = interactionBox.NormalizePoint(leapFinger.TipPosition );
				normalizedPosition *= 8;
				normalizedPosition.z = -normalizedPosition.z;
				unityFinger.transform.localPosition = ToVector3( normalizedPosition );
			}
		}
	}

	void SetVisible( GameObject obj, bool visible )
	{
		
		foreach( Renderer component in obj.GetComponents<Renderer>() ) {
			component.enabled = visible;

		}
	}

	Vector3 ToVector3( Vector v )
	{
		return new UnityEngine.Vector3( v.x, v.y, v.z );
	}
}