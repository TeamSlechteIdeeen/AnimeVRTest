using UnityEngine;
using System.Collections;

public class FirstPersonCam : MonoBehaviour
{
    public Transform Camera;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float MoveY = 0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (Camera.eulerAngles.y > 0.1f || Camera.eulerAngles.y < -180f)
        {
            Debug.Log("border reached!");
            if (yaw > 0 && Camera.eulerAngles.y > 0.1f)
            {
                MoveY = 0f;
            }
            if (yaw < 0 && Camera.eulerAngles.y < -180f)
            {
                MoveY = 0f;
            }
            else
            {
                MoveY = yaw;
            }
        } else
        {
            MoveY = yaw;
        }

        transform.eulerAngles = new Vector3(pitch, MoveY, 0.0f);
    }
}