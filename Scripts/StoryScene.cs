using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryScene : MonoBehaviour
{

    public AudioSource myAudio;
    public AudioClip[] speak;

    public GameObject headlineText;
    public GameObject firstStoryText;
    public GameObject secondStoryText;
    public GameObject thirdStoryText;
    public GameObject lastWordsText;
    public GameObject skipText;


    // Start is called before the first frame update
    void Start()
    {

        myAudio = GetComponent<AudioSource>();
        StartCoroutine("StoryAudio");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameLevel1");
        }
    }

    public void PlayAudio(int trackNumber)
    {
        myAudio.PlayOneShot(speak[trackNumber]);
    }

    public IEnumerator StoryAudio()
    {
        yield return new WaitForSeconds(1f);
        headlineText.SetActive(true);
        yield return new WaitForSeconds(5f);
        firstStoryText.SetActive(true);
        skipText.SetActive(true);
        PlayAudio(0); // TARTTUU YLEMPÄÄN PlayAudio() sisälle
        yield return new WaitForSeconds(10f);
        secondStoryText.SetActive(true);
        PlayAudio(1);
        yield return new WaitForSeconds(8f);
        thirdStoryText.SetActive(true);
        PlayAudio(2); // TARTTUU YLEMPÄÄN PlayAudio() sisälle
        yield return new WaitForSeconds(11f);
        lastWordsText.SetActive(true);
        PlayAudio(3);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameLevel1");
    }

}
