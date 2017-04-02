using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSmoke : MonoBehaviour {
    //public GameObject particle;
    public ParticleSystem particle;
    public AudioSource pew;
    public bool ArduinoFire;
    private bool AllowTrigger = true;

    public float timer;
    void Start()
    {
        pew = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && AllowTrigger || ArduinoFire && AllowTrigger)
        {
            timer = 0;
            //Instantiate(particle, endOfgun.position, Quaternion.identity);
            particle.enableEmission = true;
            pew.Play();
            AllowTrigger = false;
            ArduinoFire = false;

            Debug.Log("BAM!");
        }
        if(timer > 0.07f)
        {
            particle.enableEmission = false;
        }
        if(timer > 3)
        {
            AllowTrigger = true;
        }
    }
}
