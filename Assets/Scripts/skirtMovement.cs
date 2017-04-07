using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skirtMovement : MonoBehaviour
{
    public Transform leftSkirt;
    public Transform rightSkirt;
    public float boobFactor;

    private float timer;
    private float oldBounceAmount;
    private float actualMovement;
    private float bounceAmount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        bounceAmount = Mathf.Sin(Time.time) * (timer / 40) * boobFactor;
        actualMovement = (bounceAmount - oldBounceAmount);
        leftSkirt.Rotate(0, 0, actualMovement, Space.Self);
        rightSkirt.Rotate(0, actualMovement + 90, 0, Space.Self);


        oldBounceAmount = bounceAmount;

    }
}
