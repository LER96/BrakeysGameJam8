using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollision : MonoBehaviour
{
    private LazerLogic lazerLogic;
    private void Awake()
    {
        lazerLogic = GameObject.FindGameObjectWithTag("BoysLazer").GetComponent<LazerLogic>();
    }
    //Reset the position of the lazer
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            lazerLogic.ResetLazerPosition();
        }
    }
}
