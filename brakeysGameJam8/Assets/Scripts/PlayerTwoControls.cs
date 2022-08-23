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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Change the rotation of the player to the left
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(0, -rotationValue, 0);
        }
        //Change the rotation of the player to the right
        if (Input.GetKey(KeyCode.O))
        {
            transform.Rotate(0, rotationValue, 0);
        }
    }

    private void FixedUpdate()
    {
        //Sets the movement input J & L for Horizontal and I & K for Vertical
        horizontal2 = Input.GetAxis("Horizontal2") * Time.fixedDeltaTime * speed;
        vertical2 = Input.GetAxis("Vertical2") * Time.fixedDeltaTime * speed;

        //Move the player according to the movement input
        transform.Translate(horizontal2, 0, vertical2);
    }
}
