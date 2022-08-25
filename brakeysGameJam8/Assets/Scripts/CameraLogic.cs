using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private Transform boyPosition;
    [SerializeField] private Transform girlPosition;
    [SerializeField] private float cameraPositionZ = 0;
    [SerializeField] private Camera cameraGameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAndSetPositions();    
    }
    private void GetAndSetPositions()
    {
        if(boyPosition.transform.position.z > girlPosition.transform.position.z)
        {
            cameraPositionZ = girlPosition.transform.position.z - 15;
        }
        else
        {
            cameraPositionZ = boyPosition.transform.position.z - 15;
        }
        cameraGameobject.transform.position = new Vector3(0, 30, cameraPositionZ);


    }
}
