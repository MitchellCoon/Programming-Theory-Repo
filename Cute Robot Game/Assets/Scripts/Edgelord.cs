using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edgelord : Robot
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 5.0f;
        turnSpeed = 200.0f;
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
