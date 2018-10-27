using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour {
    public float speed = 1f;
    public float timer;

	// Update is called once per frame
    void SpawnObject()
    {
        gameObject.SetActive(true);
    }
        
	void Update () {
        transform.position += Vector3.up * Time.deltaTime * speed;
        timer += Time.deltaTime;

        if(timer > 10f)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
	}
}
