using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class FollowHand : MonoBehaviour
{

	Controller controller = new Controller();


//	public Transform m_target;
	public float     m_speed       = 5;
	public float     m_attenuation = 0.5f;
	public float scale = 50;
	public Vector3 offset;
//	public GameObject[] PalmObjects;

	private int PalmCount;
	private Vector3 m_velocity;
	private Vector3 targetposition;

	private void Update()
	{
		Frame frame = controller.Frame();
		PalmCount = frame.Fingers.Count;
		var leapPalm = frame.Hands[0];
//		var unityPalm = PalmObjects[0];

		Vector normalizedPosition = leapPalm.PalmPosition;
//		Vector offset = new Vector(2, 1, 2);
		Vector axis = normalizedPosition;
		targetposition = ToVector3 (axis);


//		m_velocity += ( m_target.position - transform.position ) * m_speed;
		m_velocity += ( targetposition - transform.position) * m_speed;
		m_velocity *= m_attenuation;
		transform.position += m_velocity *= Time.deltaTime;
	}

	Vector3 ToVector3(Vector v)
	{
		return new UnityEngine.Vector3(v.x /scale + offset.x, v.y /scale + offset.y, v.z/scale + offset.z);
	}
}
