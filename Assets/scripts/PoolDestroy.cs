using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDestroy : MonoBehaviour {
	public GameObject explosion;
	GameObject player;
	PlayerHealth playerHealth;
	public AudioSource boom;

	void Awake ()
		{
			player = GameObject.FindGameObjectWithTag("Player");
			// Debug.Log("player! " + player);
			playerHealth = player.GetComponent <PlayerHealth> ();//err
			// Debug.Log("player health! " + playerHealth);

		}
	void OnCollisionEnter (Collision col) {

		if(col.collider.tag == "Player"){
			boom.Play();
        	GameObject expl = ExplosionPooler.Instance.GetPooledObject();
			if(expl == null) return;
        	expl.transform.position = transform.position;
        	expl.transform.rotation = transform.rotation;
        	expl.SetActive(true);
			gameObject.SetActive(false);
			Attack();


		}
	}
	void Attack(){
		if(playerHealth.currentHealth > 0){
						playerHealth.TakeDamage(1);

		}
	}

}
