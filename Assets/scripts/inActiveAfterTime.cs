using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inActiveAfterTime : MonoBehaviour {

	// public AudioClip tinyboom;
	// private AudioSource source;
	
	// void Awake (){
	// 	source = GetComponent<AudioSource>();
	// }


	// Use this for initialization
	void Update () {
		if(gameObject.activeSelf){
			// source.PlayOneShot(tinyboom, 3f);
			StartCoroutine(Example());
			}	
		}
	    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(.5f);
		gameObject.SetActive(false);
    }
}
