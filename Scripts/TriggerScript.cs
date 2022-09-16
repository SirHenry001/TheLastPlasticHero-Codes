using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerScript : MonoBehaviour
{

    public GameObject[] enemyOneTrigger;
    public GameObject[] enemyOneSpawn;

    public GameObject entryDenier;
    public GameObject musicTrigger;
    public GameObject enemy;
    public GameObject enemyShoot;
    public GameObject enemySpawnEffect;

    public MusicManager musicManager;
    public GameManager gameManager;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EntryDenier")
        {
            entryDenier.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MusicTrigger")
        {
            musicManager.myAudio.Stop();
            musicManager.PlayMusic(1);
            Destroy(musicTrigger);
        }

        if (other.gameObject.tag == "EnemyOneTrigger")
        {
            GameObject smoke1 = Instantiate(enemySpawnEffect, enemyOneSpawn[0].transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
            GameObject smoke2 = Instantiate(enemySpawnEffect, enemyOneSpawn[1].transform.position, transform.rotation);
            Destroy(smoke2, 0.5f);
            GameObject smoke3 = Instantiate(enemySpawnEffect, enemyOneSpawn[2].transform.position, transform.rotation);
            Destroy(smoke3, 0.5f);

            Instantiate(enemy, enemyOneSpawn[0].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[1].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[2].transform.position, transform.rotation);
            Destroy(enemyOneTrigger[0]);
        }

        if (other.gameObject.tag == "EnemyTwoTrigger")
        {
            GameObject smoke1 = Instantiate(enemySpawnEffect, enemyOneSpawn[3].transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
            GameObject smoke2 = Instantiate(enemySpawnEffect, enemyOneSpawn[4].transform.position, transform.rotation);
            Destroy(smoke2, 0.5f);
            GameObject smoke3 = Instantiate(enemySpawnEffect, enemyOneSpawn[5].transform.position, transform.rotation);
            Destroy(smoke3, 0.5f);

            Instantiate(enemy, enemyOneSpawn[3].transform.position, transform.rotation);
            Instantiate(enemyShoot, enemyOneSpawn[4].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[5].transform.position, transform.rotation);
            Destroy(enemyOneTrigger[1]);
        }

        if (other.gameObject.tag == "EnemyThreeTrigger")
        {
            GameObject smoke1 = Instantiate(enemySpawnEffect, enemyOneSpawn[6].transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
            GameObject smoke2 = Instantiate(enemySpawnEffect, enemyOneSpawn[7].transform.position, transform.rotation);
            Destroy(smoke2, 0.5f);
            GameObject smoke3 = Instantiate(enemySpawnEffect, enemyOneSpawn[8].transform.position, transform.rotation);
            Destroy(smoke3, 0.5f);

            Instantiate(enemy, enemyOneSpawn[6].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[7].transform.position, transform.rotation);
            Instantiate(enemyShoot, enemyOneSpawn[8].transform.position, transform.rotation);
            Destroy(enemyOneTrigger[2]);
        }

        if (other.gameObject.tag == "EnemyFourTrigger")
        {
            GameObject smoke1 = Instantiate(enemySpawnEffect, enemyOneSpawn[9].transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
            GameObject smoke2 = Instantiate(enemySpawnEffect, enemyOneSpawn[10].transform.position, transform.rotation);
            Destroy(smoke2, 0.5f);
            GameObject smoke3 = Instantiate(enemySpawnEffect, enemyOneSpawn[11].transform.position, transform.rotation);
            Destroy(smoke3, 0.5f);
            GameObject smoke4 = Instantiate(enemySpawnEffect, enemyOneSpawn[12].transform.position, transform.rotation);
            Destroy(smoke4, 0.5f);

            Instantiate(enemy, enemyOneSpawn[9].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[10].transform.position, transform.rotation);
            Instantiate(enemy, enemyOneSpawn[11].transform.position, transform.rotation);
            Instantiate(enemyShoot, enemyOneSpawn[12].transform.position, transform.rotation);
            Destroy(enemyOneTrigger[3]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
