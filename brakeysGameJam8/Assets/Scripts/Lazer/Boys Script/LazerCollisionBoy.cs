using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollisionBoy : MonoBehaviour
{
    private LazerLogicBoy lazerLogic;
    private void Awake()
    {
        lazerLogic = GameObject.FindGameObjectWithTag("BoysLazer").GetComponent<LazerLogicBoy>();
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
