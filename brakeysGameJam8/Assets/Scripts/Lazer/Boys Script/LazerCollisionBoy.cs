using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollisionBoy : MonoBehaviour
{
    private LazerLogicBoy lazerLogicBoy;
    private void Awake()
    {
        lazerLogicBoy = GameObject.Find("Pivot_Lazer_Boy").GetComponent<LazerLogicBoy>();
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
            Destroy(collision.gameObject);
            lazerLogicBoy.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("GirlsEnemy"))
        {
            lazerLogicBoy.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("BoysTarget"))
        {
            lazerLogicBoy.ResetLazerPosition();
            Destroy(collision.gameObject, 7f);
        }
        else if (collision.gameObject.CompareTag("GirlsTarget"))
        {
            lazerLogicBoy.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("BothTarget"))
        {
            lazerLogicBoy.ResetLazerPosition();
        }
    }
}
