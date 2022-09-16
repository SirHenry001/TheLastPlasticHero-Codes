using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public int hpEnemy = 3;
    
    public float attackDistance = 25;

    public GameObject ammoEnemy;
    public GameObject ammoSpawnerEnemy;

    public Transform shootingTarget;

    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        shootingTarget = GameObject.Find("EnemyTarget").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("EnemyShoot", 0f, 1f);;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, shootingTarget.position) < attackDistance)
        {
            transform.LookAt(shootingTarget);
        }

    }

    void EnemyShoot()
    {
        if (Vector3.Distance(transform.position, shootingTarget.position) < attackDistance)
        {
            gameManager.PlayAudio(3);
            Instantiate(ammoEnemy, ammoSpawnerEnemy.transform.position, ammoSpawnerEnemy.transform.rotation);

        }

    }

}
