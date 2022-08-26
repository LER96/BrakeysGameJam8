using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControls : MonoBehaviour
{

    private float horizontal2 = 0;
    private float vertical2 = 0;

    [Header("Player Stats")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationValue = 0.5f;
    [SerializeField] private GameObject lazerPreview;

    private LazerLogicGirl lazerLogicGirl;
    private void Awake()
    {
        //Find the script for the lazer and set the lazer preview off
        lazerLogicGirl = GameObject.FindGameObjectWithTag("GirlsLazer").GetComponent<LazerLogicGirl>();
        lazerPreview.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Disable movement while firing the lazer
        if (!lazerLogicGirl.isActive)
        {
            //Change the rotation of the player to the left
            if (Input.GetKey(KeyCode.U))
            {
                transform.Rotate(0, -rotationValue * Time.deltaTime, 0);
            }
            //Change the rotation of the player to the right
            if (Input.GetKey(KeyCode.O))
            {
                transform.Rotate(0, rotationValue * Time.deltaTime, 0);
            }
            //Show a preview of the lazer
            if (Input.GetKey(KeyCode.Space))
            {
                lazerPreview.SetActive(true);
            }
        }

        //Fire the lazer
        if (Input.GetKeyUp(KeyCode.Space))
        {
            lazerPreview.SetActive(false);
            lazerLogicGirl.isActive = true;
        }
    }

    private void FixedUpdate()
    {
        //Disable movement while firing the lazer
        if (!lazerLogicGirl.isActive)
        {
            //Sets the movement input A & D for Horizontal and S & W for Vertical
            horizontal2 = Input.GetAxis("Horizontal2") * Time.fixedDeltaTime * speed;
            vertical2 = Input.GetAxis("Vertical2") * Time.fixedDeltaTime * speed;

            //Move the player according to the movement input
            transform.Translate(horizontal2, 0, vertical2);
        }

    }
}
