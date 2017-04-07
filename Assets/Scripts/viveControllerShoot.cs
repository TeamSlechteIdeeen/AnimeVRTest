using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viveControllerShoot : MonoBehaviour
{
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; //Essentially this is accessing
                                                                                   //SteamVR_TrackedObject.cs and telling our script
                                                                                   //and defining it here.


    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId Axis0 = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId Axis1 = Valve.VR.EVRButtonId.k_EButton_Axis1;
    private Valve.VR.EVRButtonId Axis2 = Valve.VR.EVRButtonId.k_EButton_Axis2;
    private Valve.VR.EVRButtonId Axis3 = Valve.VR.EVRButtonId.k_EButton_Axis3;
    private Valve.VR.EVRButtonId Axis4 = Valve.VR.EVRButtonId.k_EButton_Axis4;
    public bool testGrip;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    public GameObject gun;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initalized");
            return;
        }

        if (controller.GetPressDown(gripButton) || testGrip)
        {
            gun.GetComponent<GunSmoke>().ArduinoFire = true;
            Debug.Log("pew");
            testGrip = false;
        }
        if (controller.GetPressUp(gripButton))
        {
            gun.GetComponent<GunSmoke>().ArduinoFire = false;
        }

        if (controller.GetAxis(Axis0).x >= 1)
        {
            Debug.Log("Axis0 detected");
        }
        if (controller.GetAxis(Axis1).x >= 1)
        {
            Debug.Log("Axis1 detected");
        }
        if (controller.GetAxis(Axis2).x >= 1)
        {
            Debug.Log("Axis2 detected");
        }
        if (controller.GetAxis(Axis3).x >= 1)
        {
            Debug.Log("Axis3 detected");
        }
        if (controller.GetAxis(Axis4).x >= 1)
        {
            Debug.Log("Axis4 detected");
        }
    }
}

