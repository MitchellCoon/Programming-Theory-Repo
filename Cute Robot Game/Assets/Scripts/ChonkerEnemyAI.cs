using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkerEnemyAI : EnemyAI
{
    // Start is called before the first frame update
    void Start()
    {
        minDistance = 3.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        robot = gameObject.GetComponent<Robot>();
    }
}
