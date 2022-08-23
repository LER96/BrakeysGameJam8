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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Change the rotation of the player to the left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationValue, 0);
        }
        //Change the rotation of the player to the right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationValue, 0);
        }
    }

    private void FixedUpdate()
    {
        //Sets the movement input A & D for Horizontal and S & W for Vertical
        horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        //Move the player according to the movement input
        transform.Translate(horizontal, 0, vertical);
    }
}
