using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePickUp : MonoBehaviour
{

    public GameObject collectEffect;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(collectEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.PlayAudio(6);
            gameManager.AddClue();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // etsit‰‰n hierarkiasta tyhj‰ "GameManager" gameobject, jossa GameManager script on kiinni. N‰in ollen colliderissa oleva gameManager.AddClue() ymm‰rt‰‰ toisen scriptin.
    }

    // Update is called once per frame
    void Update()
    {

    }
}
