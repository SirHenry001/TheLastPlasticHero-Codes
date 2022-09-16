using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseText;
    public GameObject resumeButton;
    public GameObject quitButton;
    public PlayerController playerController;


    public void RetryGame()
    {
        playerController.gameActive = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("GameLevel1");
    }

    public void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        playerController.gameActive = true;
        Time.timeScale = 1f;
        pauseText.SetActive(false);
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void Mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 1f)
        {
            playerController.gameActive = false;
            Time.timeScale = 0f;
            pauseText.SetActive(true);
            resumeButton.SetActive(true);
            quitButton.SetActive(true);
        }

        else
        {
            playerController.gameActive = true;
            Time.timeScale = 1f;
            pauseText.SetActive(false);
            resumeButton.SetActive(false);
            quitButton.SetActive(false);
        }
    }
}
