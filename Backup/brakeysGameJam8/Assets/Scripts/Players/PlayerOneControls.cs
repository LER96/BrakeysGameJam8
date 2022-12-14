using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControls : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    private float horizontal = 0;
    private float vertical = 0;

    [Header("Player Stats")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationValue = 0.5f;
    [SerializeField] private GameObject lazerPreviewBoy;

    private LazerLogicBoy lazerLogicBoy;
    private Rigidbody boyRigidBody;
    private void Awake()
    { 
        //Find the script for the lazer and set the lazer preview off
        lazerLogicBoy = GameObject.Find("Pivot_Lazer_Boy").GetComponent<LazerLogicBoy>();
        lazerPreviewBoy.SetActive(false);
        boyRigidBody = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (boyRigidBody.velocity.y < -15)
        {
            //restart the scene
            StartCoroutine(gameManager.RestartScene());

            //Play SFX death

            //Disable the script
            this.enabled = false;
        }
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
                lazerPreviewBoy.SetActive(true);
            }
         
        }
       
        //Fire the lazer
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            lazerPreviewBoy.SetActive(false);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GirlsEnemy"))
        {
            //restart the scene
            StartCoroutine(gameManager.RestartScene());

            //Playing the death animation

            //Play SFX death

            //Disable the script
            this.enabled = false;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = 0.5f;
        }
 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
           
            speed = 5;
        }
    }
}
