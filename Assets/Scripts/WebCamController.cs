using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamController : MonoBehaviour
{
	int width = 1920;
	int height = 1080;
	int fps = 30;
	WebCamTexture webcamTexture;
	WebCamTexture webcamtexA;
	WebCamTexture webcamtexB;

	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		foreach (WebCamDevice device in devices)
		{
			Debug.Log("WebCamDevice " + device.name);
		}
		webcamtexA = new WebCamTexture(devices[0].name);   //コンストラクタ (デバイス指定）
		webcamtexB = new WebCamTexture(devices[1].name, 1280, 800, 30);   //コンストラクタ (デバイス, width, height, FPS指定）

//		webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
		GetComponent<Renderer> ().material.mainTexture = webcamtexB;
		webcamtexB.Play();
	}
}