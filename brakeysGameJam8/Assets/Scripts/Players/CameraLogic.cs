using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private Transform boyPosition;
    [SerializeField] private Transform girlPosition;
    [SerializeField] private float cameraPositionZ = 0;
    [SerializeField] private Camera cameraGameobject;

    // Update is called once per frame
    void Update()
    {
        if((boyPosition != null) && (girlPosition != null))
        {
            GetAndSetPositions();
        } 
    }
    private void GetAndSetPositions()
    {     
            //Detect who is behind and set the camera accordingly
            if (boyPosition.transform.position.z > girlPosition.transform.position.z)
            {
                cameraPositionZ = girlPosition.transform.position.z - 15;
            }
            else
            {
                cameraPositionZ = boyPosition.transform.position.z - 15;
            }
            //Move the camera to that position
            cameraGameobject.transform.position = new Vector3(0, 30, cameraPositionZ);       
    }

}
