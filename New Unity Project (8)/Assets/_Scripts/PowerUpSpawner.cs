using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject[] enemies;
    public float spawnMin, spawnMax, spawnNumber, spawnTimer;
    ObjectPooler objectPooler;
    public GameObject[] spawnPoints, bottomSpawns;

    int spawnAt;
    // Use this for initialization
    void Start()
    {
        spawnNumber = Random.Range(spawnMin, spawnMax);
        objectPooler = ObjectPooler.instance;
        spawnAt = Random.Range(0, spawnPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnNumber)
        {
            Spawn();
            spawnTimer = 0;
        }
    }

    void Spawn()
    {
        GameObject c = objectPooler.Spawn("PowerUp", bottomSpawns[spawnAt].transform.position, objectPooler.pools[1].prefab[0].transform.rotation);
            c.GetComponent<PowerUp>().spawner = spawnPoints[spawnAt];
        c.GetComponent<PowerUp>().moving = true;
        spawnNumber = Random.Range(spawnMin, spawnMax);
        spawnAt = Random.Range(0, spawnPoints.Length);

    }
}

