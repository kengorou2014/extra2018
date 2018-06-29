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
	List<int> touch_sequence = new List<int>();
	int[] touch_seq = new int[]{};
	public bool green_flag = false;
	public bool metal_flag = false;
	public bool animal_flag = false;
	public bool cyber_flag = false;

	void Start () {
		parent = gameObject.transform.parent.gameObject;
		tex_skin1 = Resources.Load<Texture2D>(skin1);
		tex_skin2 = Resources.Load<Texture2D>(skin2);
		defaultskin = Resources.Load<Texture2D>(DEFAULT_SKINNAME);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "machinebox") {
			flag = 1;
		} else if (other.gameObject.name == "forestbox") {
			flag = 2;
		} else if (other.gameObject.name == "animalbox") {
			flag = 3;
		} else if (other.gameObject.name == "cyberbox") {
			flag = 4;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "machinebox") {
			touch_sequence.Add (1);
		} else if (other.gameObject.name == "forestbox") {
			touch_sequence.Add (2);
		} else if (other.gameObject.name == "animalbox") {
			touch_sequence.Add (3);
		} else if (other.gameObject.name == "cyberbox") {
			touch_sequence.Add (4);
		}
	}

	void OnTriggerExit(Collider other) {
		flag = 0;
	}

	public int isTouching() {
		return flag;
	}

	public bool TouchedGreen() {
		return green_flag;
	}

	public bool TouchedMetal() {
		return metal_flag;
	}

	public bool TouchedAnimal() {
		return animal_flag;
	}

	public bool TouchedCyber() {
		return cyber_flag;
	}

	public List<int> touchSequence() {		
		return touch_sequence;
	}

	void Update(){
		go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = defaultskin;

		if (flag == 1) {
//			機械の手になる時の分岐
			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin1;
			metal_flag = true;
			if (!touch_sequence.Exists (x => x == 1)) {
				touch_sequence.Add (1);
			}
		} else if (flag == 2) {
//			植物の手になる分岐
			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin2;
			green_flag = true;
			if (!touch_sequence.Exists (x => x == 2)) {
				touch_sequence.Add (2);
			}
		} else if (flag == 3) {
			//			動物の手になる分岐
//			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin2;
			animal_flag = true;
			if (!touch_sequence.Exists (x => x == 3)) {
				touch_sequence.Add (3);
			}
		} else if (flag == 4) {
			//			サイバーの手になる分岐
//			go.GetComponent<SkinnedMeshRenderer> ().sharedMaterial.mainTexture = tex_skin2;
			cyber_flag = true;
			if (!touch_sequence.Exists (x => x == 4)) {
				touch_sequence.Add (4);
			}
		}
	}
}
