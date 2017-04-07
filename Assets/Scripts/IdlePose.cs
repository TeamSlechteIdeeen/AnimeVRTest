using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IdlePose : MonoBehaviour {

    public Transform PlayerMod;
    public Transform PlayerSpine;
    public Transform RightLeg;
    public Transform LeftLeg;
    public Transform RightArm;
    public Transform LeftArm;
    public Transform Neck;
    public Transform Hair1;
    public Transform Hair2;
    public float SinFactor;
    private float OldRotAmount = 0;

    private float RotAmount;
    private float ActualMovement;
    public float timer;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < 20)
        {
            RotAmount = Mathf.Sin(Time.time) * (timer / 40) * SinFactor; 
        } else
        {
            RotAmount = Mathf.Sin(Time.time) * 0.5f * SinFactor;
        }
        ActualMovement = (RotAmount - OldRotAmount);
        PlayerSpine.Rotate(0, 0, ActualMovement * 2, Space.Self);
        PlayerSpine.Translate(ActualMovement / 100, 0, 0, Space.Self);
        RightLeg.Rotate(0, 0, ActualMovement * 5, Space.Self);
        LeftLeg.Rotate(0, 0, ActualMovement * 5, Space.Self);

        RightArm.Rotate(0, 0, ActualMovement * 10, Space.Self);
        LeftArm.Rotate(0, 0, ActualMovement * 10, Space.Self);

        Hair1.Rotate(0, ActualMovement * 2, ActualMovement * 10, Space.Self);
        Hair2.Rotate(0, ActualMovement, ActualMovement * 1.1f, Space.Self);

        PlayerMod.Translate(ActualMovement / 10, 0, 0, Space.Self);
        Neck.Rotate(0, 0, ActualMovement * 10, Space.Self);
        OldRotAmount = RotAmount;



    }
}
