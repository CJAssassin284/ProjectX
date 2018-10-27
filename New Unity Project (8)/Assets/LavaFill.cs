using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFill : MonoBehaviour {
    Vector3 pos;
    bool go;
    public float speed = 2f;
    public float timer;
    public LavaScript lavaScript;
	// Use this for initialization
	void Start () {
        pos = transform.position;
        go = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (go)
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }
        if(timer >= 2)
        {
            go = false;
            
            lavaScript.start = true;
         //   gameObject.SetActive(false);
        }
        if(timer >= 5)
        {
            transform.position -= transform.up * Time.deltaTime * speed;
            if(timer >= 8)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
