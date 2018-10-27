using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject[] prefab;
        public int size;

    }
    #region Singleton

    public static ObjectPooler instance;


    private void Awake()
    {
        instance = this;
    }

    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> dictionary;
    // Use this for initialization
    void Start()
    {
        dictionary = new Dictionary<string, Queue<GameObject>>();



        foreach (Pool p in pools)
        {
            Queue<GameObject> pool = new Queue<GameObject>();

            for (int i = 0; i < p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab[Random.Range(0, p.prefab.Length)]);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }

            dictionary.Add(p.tag, pool);
        }
    }


    public GameObject Spawn(string tag, Vector3 position, Quaternion rotation)
    {
        if (!dictionary.ContainsKey(tag))
        {
            Debug.LogWarning(tag + " doesn't exist");
            return null;

        }
        GameObject objectToSpawn = dictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.SpawnObject();
        }

        dictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }



}