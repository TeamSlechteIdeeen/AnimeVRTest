using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosToCam : MonoBehaviour {
    public Transform Cam;
    public Transform Player;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        Cam.position = new Vector3(Player.position.x, Player.position.y + 2.75f, Player.position.z);
	}
}
