using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {
    public bool start = false;
    Vector3 endPos;
    public float speed = 2f;
    public GameObject claw;
	// Use this for initialization
	void Start () {
        endPos = transform.position;

        transform.position -= new Vector3(0, 3, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            claw.GetComponent<Claw>().GetBall();
        }
    }
}
