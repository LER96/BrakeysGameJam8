using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPreview : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    void Update()
    {
        //Creates a raycast infront of the player to get the distance
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //If the ray hits something that its not the player then shows the exact length of the expected player lazer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 300, layerMask))
        {
            transform.localScale = new Vector3(1,1,hitInfo.distance * 4) ;
        }
        else
        {
            //Shows the max range lazer
            transform.localScale = new Vector3(1, 1, 300);
        }

    }
}
