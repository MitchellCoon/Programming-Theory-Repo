using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float projectileRange = 10.0f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((startPosition - transform.position).magnitude > projectileRange)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("FastboiProjectile") && !other.CompareTag("EdgelordProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
