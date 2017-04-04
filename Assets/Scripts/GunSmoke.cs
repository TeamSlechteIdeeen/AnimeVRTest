using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSmoke : MonoBehaviour {
    //public GameObject particle;
    public Transform barrelEnd;
    public Transform barrelBegin;
    public GameObject bullet;
    public GameObject bulletHole;

    public float timeBetweenBullets = 3;
    public ParticleSystem particle;
    public AudioSource pew;
    public bool ArduinoFire;
    private bool AllowTrigger = true;

    public float timer;
    void Start()
    {
        pew = GetComponent<AudioSource>();
        ArduinoFire = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && AllowTrigger || ArduinoFire && AllowTrigger)
        {
            timer = 0;
            //Instantiate(particle, endOfgun.position, Quaternion.identity);
            particle.enableEmission = true;

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(barrelEnd.position, barrelEnd.up, out hit))
            {
                Collider target = hit.collider;
                float distance = hit.distance; // How far out?
                Vector3 location = hit.point; // Where did I make impact?
                GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?

                print("Hit something!");
                Debug.DrawLine(transform.position, hit.point);
                GameObject bulletInstance;
                GameObject bulletHoleInstance;
                bulletInstance = GameObject.Instantiate(bullet, hit.point, bullet.transform.rotation);
                bulletHoleInstance = GameObject.Instantiate(bulletHole, hit.point, bulletHole.transform.rotation);
                //bulletInstance.velocity = (barrelEnd.forward * 1000000);
                //bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(hit.point.forward * 1000);
                Destroy(bulletInstance, 10.5f);
            }


            //old collider method
            /*
            GameObject bulletInstance;
            bulletInstance = GameObject.Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
            //bulletInstance.velocity = (barrelEnd.forward * 1000000);
            bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(barrelEnd.forward * 1000);
            Destroy(bulletInstance, 10.5f);*/

            pew.Play();
            AllowTrigger = false;
            ArduinoFire = false;

            Debug.Log("BAM!");
        }
        if (timer > 0.07f)
        {
            particle.enableEmission = false;
        }
        if(timer > timeBetweenBullets)
        {
            AllowTrigger = true;
        }
    }
}
