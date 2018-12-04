using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonG : MonoBehaviour {

	public GameObject fade;
	private Animator anim;

	void Start(){
		anim = fade.GetComponent<Animator>();

	}

    public void OnClick()

    {
		
		anim.SetTrigger("Fade");
	   SceneManager.LoadScene("Scene02");


    }
}
