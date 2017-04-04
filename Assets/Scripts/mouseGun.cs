using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseGun : MonoBehaviour {

    //THIS SCRIPT IS FOR DEBUG PURPOSES ONLY!!
    //GUNS NEED TO BE CONTROLLED BY EITHER THE SPECIAL DESIGNED GUN CONTROLLER OR THE GOVERNMENT!
    //DO NOT PROCEED! THIS IS ILLEGAL! MOUSES AREN'T LEGALLY ALLOWED TO HAVE GUNS!!

    private float timer;
    private bool switchLock = false;
    private bool onHead = false;

    public Transform gun;
    public Transform onHeadPosition;
    public Transform normalPosition;
    public Transform arm;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float scrollSpeed = 2.0F;
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        float s = scrollSpeed * Input.GetAxis("Mouse ScrollWheel");
        transform.Rotate(0, h, (v - (v * 2)));
        arm.transform.Rotate(h, 0, (v - (v * 2)));

        if(onHead)
        {
            transform.Translate(Vector3.right * s);
        }


        timer += Time.deltaTime;
        if (Input.GetButton("Fire2") && switchLock == false)
        {
            if (onHead)
            {
                Debug.Log("Gun getting off the head");
                gun.position = normalPosition.position;
                onHead = false;
                switchLock = true;
                timer = 0;
            } else
            {
                Debug.Log("Gun going to the head");
                gun.position = onHeadPosition.position;
                onHead = true;
                switchLock = true;
                timer = 0;
            }
        }

        if (timer > 1)
        {
            switchLock = false;
        }
    }
}
