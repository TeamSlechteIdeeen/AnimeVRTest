using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletImpact : MonoBehaviour {
    public AudioSource hit;

    // Use this for initialization
    void Start () {
        hit = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            hit.Play();
            Debug.Log("JA RAAK!");
            Destroy(collision.gameObject);
        }
    }
}
