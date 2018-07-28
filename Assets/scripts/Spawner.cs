using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float setDelay;
    public float setInterval;
    void Start(){
        InvokeRepeating("Spawn", setDelay, setInterval );
    }
    void Spawn(){
        GameObject obj = NewObjectPooler.Instance.GetPooledObject();
        if(obj == null) return;
        Vector3 position = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(10f, 20.0f), Random.Range(-25.0f, 25.0f));
        obj.transform.position = position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
