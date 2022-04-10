using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float turnSpeed = 200.0f;
    private Robot robot;
    private float arenaSize = 9.5f;
    private Rigidbody body;
    private float force = 1.0f;
    public float speedModifier = 1.0f;
    private float boostDuration = 0.5f;
    private float boostCooldown = 0.3f;
    private float boostStartTime = 1000.0f;
    private bool boostActive = false;
    public bool iFrames = false;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        //robot = MainManager.Instance.robot;
        robot = gameObject.GetComponent<Robot>();
        //gameObject.AddComponent<Robot>();
        speed = robot.speed;
        turnSpeed = robot.turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) && Time.time < boostStartTime + boostDuration)
        {
            speedModifier = 2.0f;
            iFrames = true;
            if (!boostActive)
            {
                boostStartTime = Time.time;
                boostActive = true;
            }
            
        }
        else
        {
            if (Time.time > boostStartTime + boostDuration + boostCooldown)
            {
                boostActive = false;
                boostStartTime = Time.time + 1.0f;
            }
            speedModifier = 1.0f;
            iFrames = false;
        }
        if (transform.position.x <= arenaSize && transform.position.x >= -arenaSize &&
        transform.position.z <= arenaSize && transform.position.z >= -arenaSize)
        {
            transform.Translate(Vector3.forward * speed * speedModifier * Time.deltaTime * verticalInput);
        }
        else if (transform.position.x > arenaSize)
        {
            body.AddForce(new Vector3(-force, 0, 0), ForceMode.Force);
        }
        else if (transform.position.x < -arenaSize)
        {
            body.AddForce(new Vector3(force, 0, 0), ForceMode.Force);
        }
        else if (transform.position.z > arenaSize)
        {
            body.AddForce(new Vector3(0, 0, -force), ForceMode.Force);
        }
        else if (transform.position.z < -arenaSize)
        {
            body.AddForce(new Vector3(0, 0, force), ForceMode.Force);
        }
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        if (Input.GetKey(KeyCode.Space))
        {
            robot.Attack();
        }
    }
}
