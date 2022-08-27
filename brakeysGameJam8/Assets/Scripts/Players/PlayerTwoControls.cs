using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControls : MonoBehaviour
{
    [Header("Objects to Connect")]
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private Rigidbody girlRigidBody;
    [SerializeField] private GameObject lazerPreviewGirl;

    private float horizontal2 = 0;
    private float vertical2 = 0;

    [Header("Player Stats")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationValue = 0.5f;


    private LazerLogicGirl lazerLogicGirl;

    private void Awake()
    {
        //Find the script for the lazer and set the lazer preview off
        lazerLogicGirl = GameObject.Find("Pivot_Lazer_Girl").GetComponent<LazerLogicGirl>();
        lazerPreviewGirl.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (girlRigidBody.velocity.y < -15)
        {
            //restart the scene
            StartCoroutine(gameManager.RestartScene());

            //Play SFX death

            //Disable the script
            this.enabled = false;
        }
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
                lazerPreviewGirl.SetActive(true);
            }
        }

        //Fire the lazer
        if (Input.GetKeyUp(KeyCode.Space))
        {
            lazerPreviewGirl.SetActive(false);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BoysEnemy"))
        {
            //restart the scene
            StartCoroutine(gameManager.RestartScene());

            //Playing the death animation

            //Play SFX death

            //Disable the script
            this.enabled = false;
        }
    }
}
