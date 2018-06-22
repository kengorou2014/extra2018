using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderEnter: MonoBehaviour {

	GameObject parent;
	public GameObject go;
	public static int flag = 0;
	const string skin1 = "Textures/gear_1";
	const string skin2 = "Textures/green";
	const string DEFAULT_SKINNAME = "Textures/Salt_Hand_LightSkin_color";
	Texture2D tex_skin1;
	Texture2D tex_skin2;
	Texture2D defaultskin;
	List<int> permanent_flag = new List<int>();

	void Start () {
		parent = gameObject.transform.parent.gameObject;
		tex_skin1 = Resources.Load<Texture2D>(skin1);
		tex_skin2 = Resources.Load<Texture2D>(skin2);
		defaultskin = Resources.Load<Texture2D>(DEFAULT_SKINNAME);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "FirstQuadrant") {
			flag = 1;
			permanent_flag.Add (1);
		} else if (other.gameObject.name == "SecondQuadrant") {
			flag = 2;
			permanent_flag.Add (2);
		}
	}

	void OnTriggerExit(Collider other) {
		flag = 0;
	}

	public int isTouching() {
		return flag;
	}

	public List<int> permanentFlag() {
		return permanent_flag;
	}

	void Update(){
		go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = defaultskin;
		if (flag == 1) {
			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin1; 
		} else if (flag == 2) {
			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin2;
		}
	}
}
