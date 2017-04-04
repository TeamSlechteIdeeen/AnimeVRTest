using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest : MonoBehaviour {
    public GameObject bullet;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            print("Hit something!");
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetButton("Fire1"))
            {
                GameObject bulletInstance;
                bulletInstance = GameObject.Instantiate(bullet, hit.point, bullet.transform.rotation);
                //bulletInstance.velocity = (barrelEnd.forward * 1000000);
                //bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(hit.point.forward * 1000);
                Destroy(bulletInstance, 10.5f);
            }
        }

        }
}
