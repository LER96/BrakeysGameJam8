using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControls : MonoBehaviour
{
    
    private float horizontal = 0;
    private float vertical = 0;

    [Header("Player Stats")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationValue = 0.5f;
    [SerializeField] private GameObject lazerPreview;

    private LazerLogicBoy lazerLogicBoy;
    private void Awake()
    {
        //Find the script for the lazer and set the lazer preview off
        lazerLogicBoy = GameObject.FindGameObjectWithTag("BoysLazer").GetComponent<LazerLogicBoy>();
        lazerPreview.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Disable movement while firing the lazer
        if (!lazerLogicBoy.isActive)
        {
            //Change the rotation of the player to the left
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, -rotationValue * Time.deltaTime, 0);
            }
            //Change the rotation of the player to the right
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, rotationValue * Time.deltaTime, 0);
            }
            //Show a preview of the lazer
            if (Input.GetKey(KeyCode.LeftControl))
            {
                lazerPreview.SetActive(true);
            }
        }
       
        //Fire the lazer
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            lazerPreview.SetActive(false);
            lazerLogicBoy.isActive = true;
        }
    }

    private void FixedUpdate()
    {
        //Disable movement while firing the lazer
        if (!lazerLogicBoy.isActive)
        {
            //Sets the movement input A & D for Horizontal and S & W for Vertical
            horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
            vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

            //Move the player according to the movement input
            transform.Translate(horizontal, 0, vertical);
        }
      
    }
}
