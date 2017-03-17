using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByHeadset : MonoBehaviour {
    public Transform Camera;
    public Transform Neck;
    public Transform Pos;
    public Transform Hair;

    float[] lastRot = { 0, 0, 0 };

    float[] lastRot2 = { 0, 0, 0 };
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Neck.Rotate((Camera.eulerAngles.x - 26.425f) - lastRot[0], Camera.eulerAngles.y + 90 - lastRot[1], Camera.eulerAngles.z - lastRot[2], Space.Self);
        lastRot[0] = Camera.eulerAngles.x - 26.425f;
        lastRot[1] = Camera.eulerAngles.y + 90;
        lastRot[2] = Camera.eulerAngles.z;
        Pos.position = new Vector3(Camera.position.x, Pos.position.y , Camera.position.z);
    }
}
