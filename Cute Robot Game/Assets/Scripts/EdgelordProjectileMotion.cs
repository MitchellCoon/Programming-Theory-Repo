using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgelordProjectileMotion : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 500.0f;
    private Vector3 rotatePoint;
    private Vector3 offset = new Vector3(0, 0, 2.5f);
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        rotatePoint = gameObject.transform.position - gameObject.transform.rotation * offset;
        transform.RotateAround(rotatePoint, Vector3.down, 45.0f);
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotatePoint, Vector3.up, speed*Time.deltaTime);
        if (Time.time > spawnTime + 0.2f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
