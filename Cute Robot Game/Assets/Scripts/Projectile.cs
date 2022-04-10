using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float fireRate = 0.5f;
    public float lastFired = 0.0f;
    public GameObject projectile;
    public Vector3 projectileOffset = new Vector3(5, -0.5f, 0);
    public Vector3 projectileSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Fire()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastFired + fireRate)
        {
            lastFired = Time.time;
            projectileSpawn = transform.position + transform.rotation * projectileOffset;
            Instantiate(projectile, projectileSpawn, transform.rotation);
        }
    }
}
