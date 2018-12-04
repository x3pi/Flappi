using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colum : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.GetComponent<Bird>() != null)
        {
            GameControll.instance.BirdScored();
        }
    }
}
