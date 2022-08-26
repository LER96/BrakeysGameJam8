using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollisionGirl : MonoBehaviour
{
    private LazerLogicGirl lazerLogicGirl;
    private void Awake()
    {
        lazerLogicGirl = GameObject.FindGameObjectWithTag("GirlsLazer").GetComponent<LazerLogicGirl>();
    }
    //Reset the position of the lazer
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            lazerLogicGirl.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("GirlsEnemy"))
        {
            Destroy(collision.gameObject, 3);
            lazerLogicGirl.ResetLazerPosition();
        }
    }
}
