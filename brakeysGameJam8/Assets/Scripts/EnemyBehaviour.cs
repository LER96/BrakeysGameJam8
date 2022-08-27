using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 0;
    [SerializeField] private TargetTrigger targetTrigger;
    private void Start()
    {
        if (targetTrigger == null)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (targetTrigger.lowerTheWall)
        {
            transform.Translate(0, 0, -enemySpeed * Time.deltaTime);
        } 
    }
}
