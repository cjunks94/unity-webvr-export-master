using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour, IPooledObject 
{
    // The target marker.
    public Transform target;

    // Speed in units per sec.
    public float speed;

	// Use this for initialization
    public void OnObjectSpawn () 
    {
		//do something when respawned
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	

}
