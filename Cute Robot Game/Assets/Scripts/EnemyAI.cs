using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerLocation;
    private Vector3 enemyLocation;
    private float angleToPlayer;
    [SerializeField]
    private float speed = 50.0f;
    [SerializeField]
    private float turnSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        enemyLocation = transform.position;
        Vector3 target = playerLocation - enemyLocation;
        angleToPlayer = Vector3.SignedAngle(target, transform.forward, Vector3.up);

        Debug.Log("angle: " +angleToPlayer);

        if (angleToPlayer < -5.0f)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        else if (angleToPlayer > 5.0f)
        {
            transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
        }
        else if (target.magnitude > 2.0f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
