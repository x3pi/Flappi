using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControll : MonoBehaviour
{
    public static GameControll instance;

    public GameObject t1;
    public GameObject t2;

    public GameObject t3;
    public GameObject t4;

    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;

    public bool gameOver = true;
    public int score = 0;
    public Text Score1;

    public GameObject T1;


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
            UpdateCore(t1, t2, score.ToString());
            UpdateCore(t3, t4, score.ToString());


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
        SceneManager.LoadScene("Scene02", LoadSceneMode.Single);
    }

    public void Share()
    {

        Application.OpenURL("https://twitter.com/intent/tweet?text=Blog%20t%C3%A1c%20gi%E1%BA%A3%20https://x3pi.github.io/.");
    }



    public void UpdateCore(GameObject T1, GameObject T2, string s)
    {
        SpriteRenderer sr1 = T1.GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = T2.GetComponent<SpriteRenderer>();
        char[] textArray = s.ToString().ToCharArray();

        for (int i = 0; i < textArray.Length; i++)
        {
            if (i == 0) UpdateS(sr1, textArray[0].ToString());
            if (i == 1) UpdateS(sr2, textArray[1].ToString());
        }
    }

    public void UpdateS(SpriteRenderer sr, string c)
    {
        switch (c)
        {
            case "0":
                sr.sprite = s0;
                break;
            case "1":
                sr.sprite = s1;
                break;
            case "2":
                sr.sprite = s2;
                break;
            case "3":
                sr.sprite = s3;
                break;
            case "4":
                sr.sprite = s4;
                break;
            case "5":
                sr.sprite = s5;
                break;
            case "6":
                sr.sprite = s6;
                break;
            case "7":
                sr.sprite = s7;
                break;
            case "8":
                sr.sprite = s8;
                break;
            case "9":
                sr.sprite = s9;
                break;
            default:
                sr.sprite = null;
                break;
        }

    }


}
