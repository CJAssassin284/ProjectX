using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
    public float speed;
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  if (target != null)
            Vector2 targetPos = target.transform.position;
        targetPos.x = 0;
        this.transform.position = Vector2.Lerp(this.transform.position, targetPos, speed);
	}
}
