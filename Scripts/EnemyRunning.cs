using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunning : MonoBehaviour
{

    public float speed = 20f;
    public float attackDistance = 15;

    public bool playerDetected = false;

    public Transform runningTarget;
    public GameObject hitEffect;

    public GameManager gameManager;

    //---ENEMY COLLIDER TO PLAYER & FUNCTIONS TO THAT
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Osuma");
            GameObject hit = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hit, 0.5f);
            gameManager.AddHealth(2);
        }

    }

    //---ENEMY COLLIDER TO PLAYER & FUNCTIONS TO THAT


    // Start is called before the first frame update
    void Start()
    {
        runningTarget = GameObject.Find("EnemyTarget").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, runningTarget.position) < attackDistance && !playerDetected)
        {
            playerDetected = true;
        }

        if (playerDetected)
        {

            //---ENEMY MOVEMENT
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            //---ENEMY LOOK & LOOK FOLLOW PLAYER
            transform.LookAt(runningTarget);

        }

    }

}
