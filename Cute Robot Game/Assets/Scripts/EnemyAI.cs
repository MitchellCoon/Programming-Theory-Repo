using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected GameObject player;
    private Vector3 playerLocation;
    private Vector3 enemyLocation;
    private float angleToPlayer;
    [SerializeField]
    private float speed = 50.0f;
    [SerializeField]
    private float turnSpeed = 100.0f;
    protected Robot robot;
    protected float minDistance = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        robot = gameObject.GetComponent<Robot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!MainManager.Instance.gameOver && player != null)
        {
            playerLocation = player.transform.position;
            enemyLocation = transform.position;
            Vector3 target = playerLocation - enemyLocation;
            angleToPlayer = Vector3.SignedAngle(target, transform.forward, Vector3.up);

            if (angleToPlayer < -5.0f)
            {
                transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
            }
            else if (angleToPlayer > 5.0f)
            {
                transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
            }
            else if (target.magnitude > minDistance)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if(robot.health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
