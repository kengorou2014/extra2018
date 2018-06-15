using UnityEngine;
using System.Collections;
using Leap;

public class LeapControllerSample : MonoBehaviour {

	[SerializeField] GameObject m_leftTarget;
	[SerializeField] GameObject m_rightTarget;
	[SerializeField] bool m_isHeadMounted = false;

	Controller leap;
	float moveScale = 0.5f;

	void Start() {
		// Leap Controllerを生成
		leap = new Controller();

		// Optimize for top-down tracking if on head mounted display.
		Controller.PolicyFlag policy_flags = leap.PolicyFlags;
		if (m_isHeadMounted) {
			policy_flags |= Controller.PolicyFlag.POLICY_OPTIMIZE_HMD;
		}
		else {
			policy_flags &= ~Controller.PolicyFlag.POLICY_OPTIMIZE_HMD;
		}

		leap.SetPolicyFlags(policy_flags);
	}

	// LeapのVectorからUnityのVector3に変換
	Vector3 ToVector3(Vector v) {
		return new Vector3(v.x, v.y, v.z);
	}

	// ヘッドトラッキングモード時のLeapのVectorを
	// 視点位置とリンクするよう変換する
	Vector3 ConvertPosition(Vector v) {

		Vector3 pos = ToVector3(v);

		// Normalize to range of -1 to 1
		pos *= 2;
		pos -= Vector3.one;

		// Convert to the Unity coordinate.
		// Leap has especial coordinates, 0s are left, bottom and back.
		// Also See `IntaractionBox coordinates`.
		float tmp = pos.z;
		pos.x  = -pos.x;
		pos.z  = pos.y;
		pos.y  = -tmp;
		return pos;
	}

	void Update() {

		Frame frame = leap.Frame();
		InteractionBox interactionBox = frame.InteractionBox;
		HandList hands = frame.Hands;

		for (int i = 0; i < frame.Hands.Count; i++) {
			// 左手
			if (frame.Hands[i].IsLeft) {
				Vector normalizedPosition = interactionBox.NormalizePoint(frame.Hands[i].PalmPosition);

				Vector3 handPosition = ConvertPosition(normalizedPosition);

				// 変換した位置を実際に利用するスケールなどに応じて係数を掛ける
				handPosition.z -= 2.0f;
				handPosition *= moveScale;

				m_leftTarget.transform.position = handPosition;
			}
			// 右手
			else if (frame.Hands[i].IsRight) {
				Vector normalizedPosition = interactionBox.NormalizePoint(frame.Hands[i].PalmPosition);

				Vector3 handPosition = ConvertPosition(normalizedPosition);

				// 変換した位置を実際に利用するスケールなどに応じて係数を掛ける
				handPosition.z -= 2.0f;
				handPosition *= moveScale;

				m_rightTarget.transform.position = handPosition;
			}
		}
	}
}