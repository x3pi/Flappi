using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;
    Animator m_Animator;
    public float aniSpeed;

    public GameObject staticOb;

    public AudioSource audio;
    public AudioClip swing;

    private bool rUp = false;



    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        m_Animator.speed = aniSpeed;
        rb2d.Sleep();
        audio = GetComponent<AudioSource>();


    }

    void Update()
    {
        if (isDead == false)
        {
            if (rUp)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * -130f);
            }


            if (Input.GetMouseButtonDown(0))
            {
                rUp = true;
                transform.Rotate(Vector3.forward * 53f);
                GameControll.instance.gameOver = false;
                audio.clip = swing;
                audio.Play();
                rb2d.WakeUp();
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                staticOb.SetActive(false);
            }
        }

    }
    void OnCollisionEnter2D()
    {
        isDead = true;
        GameControll.instance.BirdDied();
    }


}
