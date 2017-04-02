using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoData : MonoBehaviour
{
    public Transform UpperArmL;
    public string ComPortN = "COM5";
    public GameObject gun;
    private float moveX;
    private float moveY;
    private float moveZ;

    SerialPort sp1 = new SerialPort("COM6", 9600);
    float[] lastRot = { 0, 0, 0 }; //Need the last rotation to tell how far to spin the camera

    void Start()
    {
        sp1.Open();
        sp1.WriteTimeout = 1;
        sp1.ReadTimeout = 2;
        sp1.Write("s");
    }

    void Update()
    {
        try
        {
            string value1 = sp1.ReadLine(); //Read the information
            if (value1 == "pew")
            {
                Debug.Log("PEW PEW!");
                gun.GetComponent<GunSmoke>().ArduinoFire = true;
            }
            string[] vec31 = value1.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            if (vec31[0] != "" && vec31[1] != "" && vec31[2] != "") //Check if all values are recieved
            {
                moveX = Mathf.Round((float.Parse(vec31[0]) - lastRot[0]) / 10) * 10;
                UpperArmL.Rotate(           //Rotate the camera based on the new values
                                (moveX - (moveX * 2)),
                                (Mathf.Round((float.Parse(vec31[1]) - lastRot[1]) / 10) * 10),
                                (Mathf.Round((float.Parse(vec31[2]) - lastRot[2]) / 10) * 10),
                                Space.Self
                            );
                lastRot[0] = float.Parse(vec31[0]);  //Set new values to last time values for the next loop
                lastRot[1] = float.Parse(vec31[1]);
                lastRot[2] = float.Parse(vec31[2]);
            }
        }
        catch (System.Exception)
        {
        }
    }
}