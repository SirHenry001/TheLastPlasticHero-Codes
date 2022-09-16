using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public MusicManager musicManager;
    public PlayerController playerController;

    //VARIABLES FOR PICKUPS
    public int clue;
    public int bossDoor;

    //---BOOLEANS
    //public bool pauseActive = false; ohajilla t‰‰l‰ pause menua ja mouse controllia ja saada pause toimimaan

    //---GAMEOBJECTS IN GAME
    public GameObject player;
    public GameObject boss;
    public GameObject bossExplosion;
    public GameObject mainClue;
    public GameObject clueText;
    public GameObject clueHeadline;
    public GameObject clueInfoText;
    public GameObject clueDoor;
    public GameObject finalDoor;
    public GameObject doorEffect;
    public GameObject clueEffectSpawn;
    public GameObject bossEffectSpawn;

    //---VARIABLES FOR AUDIO
    public AudioSource myAudio;
    public AudioClip[] clip;
    public AudioClip[] music;

    //myAudio.PlayOneShot(clips[0]); kerran soiva, arrayn sis‰lt‰ numero mit‰ clippi‰ kutsutaan.

    //--VARIABLES FOR UI & BUTTONS
    public GameObject gameoverText;
    public GameObject retryButton;
    public GameObject quitButton;

    //---VARIABLES FOR HEALTH (PLAYER)
    public int playerHealthMax;
    public int playerHealth = 100;
    public Image healthImage;

    //---VARIABLES FOR HEALTH (BOSS)
    public int bossHealthMax = 100;
    public int bossHealth = 100;
    public bool imageOn;
    public Image bossHealthImage;
    public Image bossBackImage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(clueInfoText, 5f);

        bossHealthImage.enabled = false;
        bossBackImage.enabled = false;
        imageOn = false;

        myAudio = GetComponent<AudioSource>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddHealth(int damage)
    {
        playerHealth -= damage;
        healthImage.fillAmount = playerHealth * 0.01f;

        if (playerHealth <= 0)
        {
            Destroy(player);
            Time.timeScale = 0;
            gameoverText.SetActive(true);
            retryButton.SetActive(true);
            quitButton.SetActive(true);
            playerController.gameActive = false;
        }

        else
        {
            Time.timeScale = 1;
            gameoverText.SetActive(false);
            retryButton.SetActive(false);
            quitButton.SetActive(false);
        }
    }

    public void BossHealth(int damage)
    {
        bossHealth -= damage;
        bossHealthImage.fillAmount = bossHealth * 0.01f;

        if (bossHealth <= 0)
        {
            Destroy(boss);
            GameObject explosion = Instantiate(bossExplosion, boss.transform.position, boss.transform.rotation);
            Destroy(explosion, 2f);
            Instantiate(mainClue, boss.transform.position, boss.transform.rotation);
        }
    }

    public void AddClue()
    {
        clue += 1;
        clueText.GetComponent<TextMeshProUGUI>().text = clue.ToString() + " x 10";

        if (clue == 10)
        {
            Destroy(clueDoor);
            PlayAudio(0);
            GameObject smoke1 = Instantiate(doorEffect,clueEffectSpawn.transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
        }

        if (clue == 11)
        {
            finalDoor.SetActive(true);
            clueText.SetActive(false);
            clueHeadline.SetActive(false);
            bossHealthImage.enabled = true;
            bossBackImage.enabled = true;
            imageOn = true;
            PlayAudio(5);
            musicManager.myAudio.Stop();
            musicManager.PlayMusic(2);
        }
    }

    public void BossDoor()
    {
        bossDoor -= 1;

        if (bossDoor == 0)
        {
            finalDoor.SetActive(false);
            PlayAudio(0);
            GameObject smoke1 = Instantiate(doorEffect, bossEffectSpawn.transform.position, transform.rotation);
            Destroy(smoke1, 0.5f);
        }
    }

    public void PlayAudio(int trackNumber)
    {
        myAudio.PlayOneShot(clip[trackNumber]);
 
    }

    public void PlayMusic(int trackNumber)
    {
        myAudio.PlayOneShot(music[trackNumber]);
    }


}
