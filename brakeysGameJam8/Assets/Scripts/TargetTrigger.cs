using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private Transform loweredWall;
    private readonly float loweringSpeed = -5;
    private float loweringAmount = 0;
    private bool lowerTheWall = false;

    // Start is called before the first frame update
    void Start()
    {
        lowerTheWall = false;
        loweringAmount = loweredWall.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (lowerTheWall && loweredWall != null)
        {
            loweringAmount += loweringSpeed * Time.deltaTime;
            loweredWall.position = new Vector3(loweredWall.position.x, loweringAmount, loweredWall.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("GirlsLazer")) && (this.CompareTag("GirlsTarget")))
        {
            lowerTheWall = true;
            Destroy(loweredWall.gameObject, 2.1f);
        }
        if((collision.gameObject.CompareTag("BoysLazer")) && (this.CompareTag("BoysTarget")))
        {
            lowerTheWall = true;
        }
        
    }
}
