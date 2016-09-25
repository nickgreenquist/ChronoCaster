using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Vector3 movement;
    public float speed = 3;
    GameObject enemy;
    Transform enemyTransform;
    Vector3 enemyPosition;
    public float speedMult;

    GameObject player;
    Transform playerTransform;
    Vector3 playerPosition;

    Rigidbody enemyRigidbody;

    public bool isBlob = false;

    // Use this for initialization
    void Start()
    {
        speedMult = .1f;

        player = GameObject.Find("Player");
        playerTransform = player.transform;
        playerPosition = playerTransform.position;

        enemyTransform = this.transform;
        enemyPosition = enemyTransform.position;

        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //scale speed to simulate slowing down and speeding up...for blobs only
        if (isBlob)
        {
            speed = speed + speedMult;
            if (speed > 3)
            {
                speedMult = -.1f;
            }
            if (speed < 0)
            {
                speedMult = .1f;
            }
        }
		
        enemyTransform.LookAt(playerPosition);
        enemyPosition = enemyTransform.position;
        playerPosition = playerTransform.position;
        Movement();
    }

    void Movement()
    {
        movement = playerPosition - enemyPosition;
        movement.y = 0;

        //Movement is normalized, multipled by speed and dealtatime
        movement = movement.normalized * speed * Time.deltaTime;

        //Adds movemtn to current position
        //Uses rigidbody to move with physics
        enemyRigidbody.MovePosition(transform.position + movement);
    }
}
