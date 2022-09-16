using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AmmoPlayer : MonoBehaviour
{

    public float speed = 30f;

    public GameObject enemyExplosion;
    public GameObject fireEnemyExplosion;
    public GameObject bossExplosion;
    public GameObject wallExplosion;
    public GameObject glassExplosion;

    public GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            GameObject enemyHit = Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(enemyHit, 1f);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "FireEnemy")
        {
            Destroy(other.gameObject);
            GameObject enemyHit = Instantiate(fireEnemyExplosion, transform.position, transform.rotation);
            Destroy(enemyHit, 2f);
            Destroy(gameObject);
        }


        if (other.gameObject.tag == "EnemyShoot")
        {
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(explosion, 1f);
            Destroy(gameObject);
            gameManager.BossDoor();
        }

        if (other.gameObject.tag == "Wall")
        {
            GameObject explosion = Instantiate(wallExplosion, transform.position, transform.rotation);
            Destroy(explosion, 1f);
            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Glass")
        {
            GameObject explosion = Instantiate(glassExplosion, transform.position, transform.rotation);
            Destroy(explosion, 1f);
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            GameObject hit = Instantiate(bossExplosion, transform.position, transform.rotation);
            Destroy(hit, 2f);
            gameManager.BossHealth(2);
        }

        if (other.gameObject.tag == "AmmoDenier")
        {
            Destroy(gameObject);
        }



    }

 


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
