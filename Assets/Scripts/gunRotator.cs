using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotator : MonoBehaviour {
    public Transform gunObject;
    public Transform controllerModel;

    float[] lastRot = { 0, 0, 0 }; 
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gunObject.Rotate((controllerModel.rotation.x - lastRot[0]), (controllerModel.rotation.y - lastRot[1]), (controllerModel.rotation.z - lastRot[2]), Space.Self);
        //gunObject.rotation = Quaternion()
        lastRot[0] = controllerModel.rotation.x;  //Set new values to last time values for the next loop
        lastRot[1] = controllerModel.rotation.y;
        lastRot[2] = controllerModel.rotation.z;

    }
}
