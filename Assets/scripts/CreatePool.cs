using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton
    public static CreatePool Instance;

	private void Awake()
	{
        Instance = this;
	}
	#endregion
	public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Use this for initialization
    void Start()
    //create new pool of a certain size(size)
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                //set these all to inactive
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                objectPool.Enqueue(obj);

            }
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

  
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    //if we have a game object active in our queue then return that obj
    {
        if (!poolDictionary.ContainsKey(tag)){
            Debug.LogWarning("pool with tag " + tag + " does not exist");
                 return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObject != null){
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;

    }
}
