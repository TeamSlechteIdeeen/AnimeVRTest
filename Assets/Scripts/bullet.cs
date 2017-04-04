using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public Transform barrelEnd;
    public GameObject projectile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject bulletInstance = GameObject.Instantiate(projectile, barrelEnd.transform.position, barrelEnd.transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 50000);
    }
}
