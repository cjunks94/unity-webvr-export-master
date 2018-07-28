using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount;

	List<GameObject> pooledObjects;

    #region Singleton
    public static ExplosionPooler Instance;

	private void Awake()
	{
        Instance = this;
	}
	#endregion

	void Start () {
		pooledObjects = new List<GameObject>();
		for(int i = 0; i < pooledAmount; i++){
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}

	}
	public GameObject GetPooledObject (){
		for(int i = 0; i < pooledObjects.Count; i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}

		return null;
	}

}
