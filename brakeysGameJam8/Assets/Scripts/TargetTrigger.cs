using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private Transform loweredWall;
    [SerializeField] private GameObject antiChesse;
    private BoxCollider wallCollider;
    private MeshRenderer wallSkin;
    private readonly float loweringSpeed = -5;
    private float loweringAmount = 0;
    private bool lowerTheWall = false;
    private int hitCounter = 0;
    private bool isHit;

    private void Awake()
    {
        hitCounter = 0;
        wallCollider = gameObject.GetComponent<BoxCollider>();
        wallSkin = gameObject.GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        lowerTheWall = false;
        loweringAmount = loweredWall.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lowerTheWall) && (loweredWall != null))
        {
            loweringAmount += loweringSpeed * Time.deltaTime;
            loweredWall.position = new Vector3(loweredWall.position.x, loweringAmount, loweredWall.position.z);
        }
    }
    IEnumerator TimeTheShot()
    {
        if (!isHit)
        {
            isHit = true;
            yield return new WaitForSeconds(1);
            if (hitCounter == 11)
            {
                
                lowerTheWall = true;
                wallCollider.enabled = false;
                wallSkin.enabled = false;
                Destroy(antiChesse, 2.8f);
                Destroy(loweredWall.gameObject, 10f);
            }
            else
            {
               
                hitCounter = 0;
                wallCollider.enabled = false;
                wallSkin.enabled = false;
                yield return new WaitForSeconds(0.25f);
                wallCollider.enabled = true;
                wallSkin.enabled = true;
            }
        }
        isHit = false;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("GirlsLazer")) && (this.CompareTag("GirlsTarget")))
        {
            lowerTheWall = true;
            wallCollider.enabled = false;
            wallSkin.enabled = false;
            Destroy(antiChesse, 2.8f);
            Destroy(loweredWall.gameObject, 10f);
        }
        if((collision.gameObject.CompareTag("BoysLazer")) && (this.CompareTag("BoysTarget")))
        {
            lowerTheWall = true;
            wallCollider.enabled = false;
            wallSkin.enabled = false;
            Destroy(antiChesse, 2.8f);
            Destroy(loweredWall.gameObject, 10f);
        }
        if ((collision.gameObject.CompareTag("BoysLazer")) && (this.CompareTag("BothTarget")))
        {
            hitCounter += 1;
            StartCoroutine(TimeTheShot());
        }
        if ((collision.gameObject.CompareTag("GirlsLazer")) && (this.CompareTag("BothTarget")))
        {
            hitCounter += 10;
            StartCoroutine(TimeTheShot());
        }
    }
}
