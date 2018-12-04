using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    Animator m_Animator;
    public float aniSpeed;

    void Start()
    {
        //Get the animator, attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void OnGUI()
    {

        m_Animator.speed = aniSpeed;
    }
}
