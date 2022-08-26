using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollisionBoy : MonoBehaviour
{
    private LazerLogicBoy lazerLogicBoy;
    private void Awake()
    {
        lazerLogicBoy = GameObject.FindGameObjectWithTag("BoysLazer").GetComponent<LazerLogicBoy>();
    }
    //Reset the position of the lazer
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            lazerLogicBoy.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("BoysEnemy"))
        {
            Destroy(collision.gameObject, 0.5f);
            lazerLogicBoy.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("GirlsEnemy"))
        {
            lazerLogicBoy.ResetLazerPosition();
        }
    }
}
