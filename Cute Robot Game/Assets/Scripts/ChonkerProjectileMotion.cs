using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkerProjectileMotion : MonoBehaviour
{
    public float speed = 500.0f;
    private Vector3 rotatePoint;
    private Vector3 offset = new Vector3(0, 0, 2.5f);
    private float spawnTime;
    private float duration = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, 0);
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + duration)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FastboiProjectile") || other.CompareTag("EdgelordProjectile"))
        {
            Destroy(other);
        }
    }
}
