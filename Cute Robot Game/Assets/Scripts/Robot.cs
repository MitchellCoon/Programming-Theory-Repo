using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private int m_health = 100;
    public int health
    {
        get{return m_health;}
        set
        {
            if (value < 0)
            {
                Debug.LogError("You can't set a negative value for health");
            }
            else
            {
                m_health = value;
            }
        }
    }
    public GameObject canvas;
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public float turnSpeed = 200.0f;
    public float projectileSpeed = 10.0f;
    public float fireRate = 0.1f;
    public float lastFired = 0.0f;
    public GameObject projectile;
    public Vector3 projectileOffset = new Vector3(5, -0.5f, 0);
    public Vector3 projectileSpawn;
    private Rigidbody body;
    private float forceMultiplier = 1.0f;
    private Vector3 forceDirection;
    private int damage;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        lastFired = 0.0f;
        canvas = GameObject.Find("Canvas");
        if(gameObject.CompareTag("Player"))
        {
            canvas.GetComponent<MenuUIHandler>().UpdateHealth(health);
            playerController = gameObject.GetComponent<PlayerController>();
        }
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        if(gameObject.CompareTag("Player"))
        {
            canvas.GetComponent<MenuUIHandler>().UpdateHealth(health);
        }
        if (health <=0)
        {
            if(gameObject.CompareTag("Player"))
            {
                MainManager.Instance.GameOver();
            }
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        if(!MainManager.Instance.gameOver)
        {
            if(Time.time > lastFired + fireRate)
            {
                lastFired = Time.time;
                projectileSpawn = this.gameObject.transform.position + this.gameObject.transform.rotation * projectileOffset;
                Instantiate(projectile, projectileSpawn, transform.rotation);
            }
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Player"))
        {
            playerController = gameObject.GetComponent<PlayerController>();
        }
        if (other.gameObject.CompareTag("FastboiProjectile"))
        {
            damage = 10;
        }
        else if (other.gameObject.CompareTag("EdgelordProjectile"))
        {
            damage = 20;
        }
        else if (other.gameObject.CompareTag("ChonkerProjectile"))
        {
            damage = 1;
            forceDirection = transform.position - other.transform.position;
            body = gameObject.GetComponent<Rigidbody>();
            body.AddForce(forceMultiplier * forceDirection, ForceMode.Impulse);
        }
        if(!gameObject.CompareTag("Player"))
        {
            TakeDamage(damage);
        }
        else if(!playerController.iFrames)
        {
            TakeDamage(damage);
        }
    }


}
