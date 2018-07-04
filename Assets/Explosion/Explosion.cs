using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject ExploadObj;
    public GameObject ExploadPos;
    // Update is called once per frame
    void Update () {
        //スペースキーを押したら
        if (Input.GetButtonDown ("Jump")) {
            Instantiate (ExploadObj, ExploadPos.transform.position, Quaternion.identity);

        }
    }
}