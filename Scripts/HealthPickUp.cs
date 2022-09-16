using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject healthEffect;
    public GameObject healthImage;

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(healthEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.PlayAudio(7);
            gameManager.playerHealth = 100;
            gameManager.healthImage.fillAmount = gameManager.playerHealth = 100;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
