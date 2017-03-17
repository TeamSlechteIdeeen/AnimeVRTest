using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoData : MonoBehaviour
{
    public Transform UpperArmL;
    public string ComPortN = "COM5";
    private float moveX;
    private float moveY;
    private float moveZ;

    private float initX;
    private float initY;
    private float initZ;

    //SerialPort sp1 = new SerialPort("\\\\.\\COM8", 9600);
    SerialPort sp1 = new SerialPort("COM4", 9600);
    //SerialPort sp1 = new SerialPort("\\\\.\\COM10", 9600);
    //SerialPort sp2 = new SerialPort("COM3", 9600);
    //SerialPort sp3 = new SerialPort("COM5", 9600);
    //SerialPort sp4 = new SerialPort("COM7", 9600);
    float[] lastRot = { 0, 0, 0 }; //Need the last rotation to tell how far to spin the camera

    void Start()
    {
        sp1.Open();
        //sp2.Open();
        //sp3.Open();
        //sp4.Open();
        //sp1.ReadTimeout = sp2.ReadTimeout = sp3.ReadTimeout = sp4.ReadTimeout = 1;
        //sp1.WriteTimeout = sp2.WriteTimeout = sp3.WriteTimeout = sp4.WriteTimeout = 1;
        sp1.WriteTimeout = 1;
        sp1.ReadTimeout = 4;
        sp1.Write("s");
        //sp2.Write("s");
        //sp3.Write("s");
        //sp4.Write("s");
    }

    void Update()
    {
        //sp2.Write("s");
        //sp3.Write("s");
        //sp4.Write("s");
        try
        {
            //print(sp.ReadLine());
            string value1 = sp1.ReadLine(); //Read the information
            //string value2 = sp2.ReadLine();
            //string value3 = sp3.ReadLine();
            //string value4 = sp4.ReadLine();
            string[] vec31 = value1.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            print(value1);
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

            /*
            string[] vec32 = value2.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            print(value2);
            if (vec32[0] != "" && vec32[1] != "" && vec32[2] != "") //Check if all values are recieved
            {
                UpperArmR.Rotate(           //Rotate the camera based on the new values
                                float.Parse(vec32[0]) - lastRot[0],
                                float.Parse(vec32[1]) - lastRot[1],
                                float.Parse(vec32[2]) - lastRot[2],
                                Space.Self
                            );
                lastRot[0] = float.Parse(vec32[0]);  //Set new values to last time values for the next loop
                lastRot[1] = float.Parse(vec32[1]);
                lastRot[2] = float.Parse(vec32[2]);
            }

            string[] vec33 = value3.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            print(value3);
            if (vec33[0] != "" && vec33[1] != "" && vec33[2] != "") //Check if all values are recieved
            {
                UnderArmL.Rotate(           //Rotate the camera based on the new values
                                float.Parse(vec33[0]) - lastRot[0],
                                float.Parse(vec33[1]) - lastRot[1],
                                float.Parse(vec33[2]) - lastRot[2],
                                Space.Self
                            );
                lastRot[0] = float.Parse(vec33[0]);  //Set new values to last time values for the next loop
                lastRot[1] = float.Parse(vec33[1]);
                lastRot[2] = float.Parse(vec33[2]);
            }

            string[] vec34 = value4.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            print(value4);
            if (vec34[0] != "" && vec34[1] != "" && vec34[2] != "") //Check if all values are recieved
            {
                UnderArmR.Rotate(           //Rotate the camera based on the new values
                                float.Parse(vec34[0]) - lastRot[0],
                                float.Parse(vec34[1]) - lastRot[1],
                                float.Parse(vec34[2]) - lastRot[2],
                                Space.Self
                            );
                lastRot[0] = float.Parse(vec34[0]);  //Set new values to last time values for the next loop
                lastRot[1] = float.Parse(vec34[1]);
                lastRot[2] = float.Parse(vec34[2]);
            }*/

        }
        catch (System.Exception)
        {
        }
    }
}