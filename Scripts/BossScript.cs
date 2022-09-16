using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 1f;
    public float timer;
    public float attackDistance = 30f;

    public bool playerDetected = false;

    public GameObject ammoBoss;
    public GameObject ammoSpawner;
    public GameObject ammoSpawner1;
    public GameObject ammoSpawner2;
    public GameObject ammoSpawner3;
    public GameObject ammoSpawner4;

    public Transform shootingTarget;

    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("BossShoot", 0f, 0.8f);
        InvokeRepeating("AngleShoot", 0f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {



        if (Vector3.Distance(transform.position, shootingTarget.position) < attackDistance && !playerDetected)
        {
            playerDetected = true;
        }

        if (playerDetected)
        {

            Quaternion targetRotation = Quaternion.LookRotation(shootingTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,rotationSpeed * Time.deltaTime);

            transform.parent.Translate(Vector3.back * speed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer > 3f)
            {
                speed = -speed;
                timer = 0f;
            }


        }
    }

    void BossShoot()
    {
        if (Vector3.Distance(transform.position, shootingTarget.position) < attackDistance)
        {
            gameManager.PlayAudio(3);
            Instantiate(ammoBoss, ammoSpawner.transform.position, ammoSpawner.transform.rotation);
            Instantiate(ammoBoss, ammoSpawner1.transform.position, ammoSpawner1.transform.rotation);
            Instantiate(ammoBoss, ammoSpawner2.transform.position, ammoSpawner2.transform.rotation);
        }
    }

    void AngleShoot()
    {
        if (Vector3.Distance(transform.position, shootingTarget.position) < attackDistance)
        {
            gameManager.PlayAudio(3);
            Instantiate(ammoBoss, ammoSpawner3.transform.position, ammoSpawner3.transform.rotation);
            Instantiate(ammoBoss, ammoSpawner4.transform.position, ammoSpawner4.transform.rotation);
        }
 
    }

}
