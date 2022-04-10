using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chonker : Robot
{
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        speed = 2.5f;
        turnSpeed = 150.0f;
        lastFired = 0.0f;
        canvas = GameObject.Find("Canvas");
        if(gameObject.CompareTag("Player"))
        {
            canvas.GetComponent<MenuUIHandler>().UpdateHealth(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
