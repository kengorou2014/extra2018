using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour
{
	// Skyboxのマテリアル

	SequenceController seqcontroller;
	private int flag;
	public Material growsky;
	public Material rotsky;

	void Start()
	{
		// Skyboxを変更する
		seqcontroller = GameObject.Find ("InteractionObject").GetComponent<SequenceController>();

	}

	void Update()
	{
		flag = seqcontroller.ResultFlag ();
		if (flag == 1) {
			RenderSettings.skybox = growsky;
		} else if (flag == 2) {
			RenderSettings.skybox = rotsky;
		}
	}
}