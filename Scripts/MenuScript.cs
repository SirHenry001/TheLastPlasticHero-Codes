using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public AudioSource myAudio;
    public AudioClip[] clip;

    public GameObject startButton;
    public GameObject controlsButton;
    public GameObject quitButton;
    public GameObject backButton;
    public GameObject controlsText;
    public GameObject controlsTextTwo;

    public bool imageOn;
    public Image controlsBackImage;

    public void StartGame()
    {
        PlayClip(0);

        Time.timeScale = 1;
        SceneManager.LoadScene("StoryScene");
    }

    public void MainMenu()
    {
        PlayClip(2);

        controlsBackImage.enabled = false;
        imageOn = false;

        controlsButton.SetActive(true);
        startButton.SetActive(true);
        quitButton.SetActive(true);

        controlsText.SetActive(false);
        controlsTextTwo.SetActive(false);
        backButton.SetActive(false);
    }

    public void Controls()
    {
        PlayClip(1);

        controlsBackImage.enabled = true;
        imageOn = true;

        controlsButton.SetActive(false);
        startButton.SetActive(false);
        quitButton.SetActive(false);

        controlsText.SetActive(true);
        controlsTextTwo.SetActive(true);
        backButton.SetActive(true);
    }

    public void QuitGame()
    {
        PlayClip(3);

        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

        controlsBackImage.enabled = false;
        imageOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClip(int trackNumber)
    {
        myAudio.PlayOneShot(clip[trackNumber]);
    }
}
