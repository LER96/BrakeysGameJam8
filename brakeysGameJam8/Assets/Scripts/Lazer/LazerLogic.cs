using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LazerLogic : MonoBehaviour
{
    private readonly float lazerSpeed = 150f;
    private float lazerLifeTime = 1f;
    public bool isActive = false;
    private bool callOnce;

    void Start()
    {
        isActive = false;
        callOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the size of the lazer only when the player press the button
        if (isActive)
        {
            //Add the size factor to the lazer
            lazerLifeTime += lazerSpeed * Time.deltaTime;

            //Set the scale
            transform.localScale = new Vector3(1, 1, lazerLifeTime);

            //Failsafe measurment activate
            StartCoroutine(ResetIfMissedWall());
        }
        else
        {
            //Disable the option for the lazer to stop to early
            StopAllCoroutines();
            callOnce = false;
        }
       
    }
    //Reseting the razer position
    public void ResetLazerPosition()
    {
        isActive = false;
        lazerLifeTime = 1;
        transform.localScale = new Vector3(1, 1, lazerLifeTime);
    }
    IEnumerator ResetIfMissedWall()
    {
        //call the reset function only once
        if (!callOnce)
        {
            callOnce = true;
            yield return new WaitForSeconds(2f);
            ResetLazerPosition();
            yield return null;
            callOnce = false;
        }
    }
}
