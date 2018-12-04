using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public static GameControll instance;

    public bool gameOver = true;
    private int score = 0;


    public AudioSource audio;
    public AudioClip audioDie;
    public AudioClip audioScore;
    public AudioClip audioHit;


    public GameObject dieShow;
    public GameObject btOk;
    public GameObject btShare;



    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BirdScored()
    {
        if (gameOver == false)
        {
            audio.clip = audioScore;
            audio.Play();
            score++;
        }

    }

    public void BirdDied()
    {
        if (gameOver == false)
        {

            StartCoroutine(playEngineSound());
            gameOver = true;
            dieShow.SetActive(true);
            btOk.SetActive(true);
            btShare.SetActive(true);
        }
    }




    IEnumerator playEngineSound()
    {
        audio.clip = audioHit;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = audioDie;
        audio.Play();
    }

    public void RestartGame()
    {
        Application.LoadLevel(1);
    }

    public void Share(){

        Application.OpenURL("https://twitter.com/intent/tweet?text=Blog%20t%C3%A1c%20gi%E1%BA%A3%20https://x3pi.github.io/.");
    }


}
