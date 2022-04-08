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

    private GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void TakeDamage(int damage)
    {
        Debug.Log(health);
        health = Mathf.Max(0, health - damage);
        if (health <=0)
        {
            if(gameObject.CompareTag("Player"))
            {
                MainManager.Instance.gameOver = true;
            }
            Destroy(gameObject);
        }
    }

    protected void Attack()
    {

    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("FastboiProjectile"))
        {
            TakeDamage(10);
        }
        else if (other.gameObject.CompareTag("EdgelordProjectile"))
        {
            TakeDamage(20);
        }
        else if (other.gameObject.CompareTag("ChonkerProjectile"))
        {
            TakeDamage(50);
        }
    }


}
