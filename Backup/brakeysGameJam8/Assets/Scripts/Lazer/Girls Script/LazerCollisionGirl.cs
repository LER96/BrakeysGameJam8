using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollisionGirl : MonoBehaviour
{
    private LazerLogicGirl lazerLogicGirl;
    
    private void Awake()
    {
        lazerLogicGirl = GameObject.Find("Pivot_Lazer_Girl").GetComponent<LazerLogicGirl>();
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
            Destroy(collision.gameObject, 0.5f);
            lazerLogicGirl.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("BoysEnemy"))
        {
            lazerLogicGirl.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("GirlsTarget"))
        {
            lazerLogicGirl.ResetLazerPosition();
            Destroy(collision.gameObject, 7f);
        }
        else if (collision.gameObject.CompareTag("BoysTarget"))
        {
            lazerLogicGirl.ResetLazerPosition();
        }
        else if (collision.gameObject.CompareTag("BothTarget"))
        {
            lazerLogicGirl.ResetLazerPosition();
        }
    }
}
