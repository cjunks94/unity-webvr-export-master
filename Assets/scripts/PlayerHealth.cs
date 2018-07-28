using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//FIX AUDIO
//I MADE A LOT OF STUFF FOR MY LINE THAT DOESNT WORK AND WILL PROB BE SCRAPPED
//FIX FLASH HURT STUFF
public class PlayerHealth : MonoBehaviour {
	
	public int startingHealth = 3;
	public int currentHealth;
	public float flashSpeed = 5f;
	public Slider healthSlider; 
	public Image damageImage;
	public Image sliderColor;
	public Text deathImage;
	public AudioSource hurtClip;
	public AudioSource deathClip;
	public Color deathColor = new Color(1f,0f,0f,0f);

	// AudioSource playerAudio; //make an audio thingy on our player...
	GameObject player;
	GameObject gun;
	CharacterController controller;
	GunScript shoot;
	bool isDead;
	bool damaged;


	// Use this for initialization
	void Awake () {
		//better way?

		player = GameObject.FindGameObjectWithTag("Player");//get the stuff
		gun = GameObject.FindGameObjectWithTag("Gun");

		controller = player.GetComponent<CharacterController>();
		shoot = gun.GetComponent<GunScript>();
		//~~~~~~~~~~
		currentHealth = startingHealth;

	}
	
	// Update is called once per frame
	void Update () {
		if (damaged){
			damageImage.color = Color.red;//flash when injured
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);//once we are done being injured change the values of our hurting image
		}
		damaged = false;
		 //makes being damaged instant then reset to false.
	}
	public void TakeDamage (int amount){
		damaged = true;
		hurtClip.Play ();
		currentHealth -= amount;//amount should just be one in our case.
		healthSlider.value = currentHealth;//health slider will adjust
		switch (currentHealth)
      {
          case 2:
            	sliderColor.color = Color.yellow;
              	break;
          case 1:
				sliderColor.color = Color.red;
              	break;
          default:
             	break;
      }
		if(currentHealth <= 0 && !isDead){
			Death ();//are we dead?
		}
	}
	void Death (){
		isDead = true;
		deathImage.color = deathColor;//displauy death screen
		controller.enabled = false;//disable controls
		shoot.enabled = false;//disable shooting
		deathClip.Play();
	}
}
