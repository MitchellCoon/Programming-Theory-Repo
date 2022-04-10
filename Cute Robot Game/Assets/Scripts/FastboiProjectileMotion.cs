using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastboiProjectileMotion : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EdgelordProjectile"))
        {
            speed = -speed;
            MaterialPropertyBlock color = new MaterialPropertyBlock();
            color.SetColor("_Color", Color.blue);
            GetComponent<Renderer>().SetPropertyBlock(color);
        }
    }
}
