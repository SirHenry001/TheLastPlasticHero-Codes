using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public GameObject winText;
    public GameObject retryButton;
    public GameObject quitButton;

    public PlayerController playerController;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("osuuosuuu");
            winText.SetActive(true);
            retryButton.SetActive(true);
            quitButton.SetActive(true);
            Time.timeScale = 0f;
            playerController.gameActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
