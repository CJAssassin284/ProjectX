using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public GameObject spawner;
    public bool moving;
    public float timer;
	// Use this for initialization
	void Start () {
        StartCoroutine(Done(3f));
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawner.transform.position, Time.deltaTime * 3);
        }
        else
            transform.position = transform.position;
	}

    IEnumerator Done(float wait)
    {
        yield return new WaitForSeconds(wait);
        moving = false;
    }
}
