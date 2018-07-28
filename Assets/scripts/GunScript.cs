using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	// Use this for initialization
	public Transform barrel;
	public float range = 50f;
	public float timeBetweenShots = .5f;
	public float effectDisplayTime = .2f;
	public ParticleSystem muzzleFlash;
	public AudioSource boom;
	public AudioSource pew;
	float timer;

	void Update(){
		timer += Time.deltaTime;
		if(Input.GetButtonDown("Fire1") && timer >= timeBetweenShots){//prob need to change fire1
			StartCoroutine("Fire");
		}
	}
	IEnumerator Fire (){
		RaycastHit hit;
		timer = 0f;
		muzzleFlash.Play();
		pew.Play();

		Ray ray = new Ray(barrel.position, barrel.forward);
		if(Physics.Raycast(ray, out hit, 50)){
			Debug.Log("ray getpoint " + ray.GetPoint(40));
			if(hit.collider.tag == "Enemy"){
				boom.Play();
				GameObject expl = ExplosionPooler.Instance.GetPooledObject();
				expl.transform.position = hit.point;
				expl.transform.rotation = transform.rotation;
				expl.SetActive(true);

				//destroy enemy asteroid
				hit.collider.gameObject.SetActive(false);
				ScoreManager.score += 10;
				//inc score
			}
		}
		Debug.DrawRay(barrel.position, barrel.forward * range, Color.green);
		yield return null;
	}
}
