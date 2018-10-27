using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawner : MonoBehaviour {
    public GameObject[] enemies;
    public float spawnMin, spawnMax, spawnNumber, spawnTimer;
    ObjectPooler objectPooler;
    public Vector2 startPoint, endPoint, spawnPoint;
	// Use this for initialization
	void Start () {
        spawnNumber = Random.Range(spawnMin, spawnMax);
        objectPooler = ObjectPooler.instance;
        spawnPoint = new Vector2(Random.Range(startPoint.x,endPoint.x),-5);
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnNumber)
        {
            Spawn();
            spawnTimer = 0;
        }
	}

    void Spawn()
    {
        objectPooler.Spawn("Enemy", spawnPoint, objectPooler.pools[0].prefab[0].transform.rotation);
        spawnNumber = Random.Range(spawnMin, spawnMax);
        spawnPoint = new Vector2(Random.Range(startPoint.x, endPoint.x), -5);

    }
}
