using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {
    public bool goingDown, goingUp, stay;
    public float speed;
    GameObject player;
    public GameObject[] holder;
    bool done = true;
    int randHolder;
    Vector3 holder1, holder2;
    bool doOnce;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        randHolder = Random.Range(1, 3);
        holder1 = new Vector3(holder[0].transform.position.x, 3, transform.position.z);
        holder2 = new Vector3(holder[1].transform.position.x, 3, transform.position.z);
        pos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update () {
		if(goingDown)
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }
        else if(goingUp)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        else if(stay)
        {
            if (randHolder == 1)
                transform.position = Vector3.MoveTowards(transform.position, holder1, Time.deltaTime * speed);
            else if(randHolder == 2)
                transform.position = Vector3.MoveTowards(transform.position, holder2, Time.deltaTime * speed);

            if(!doOnce)
            {
                StartCoroutine(Drop(3f,1f,2f));
            }
        }

    }

    public void GetBall()
    {
        if (done)
        {
            StartCoroutine(Retrieve(3f, 4.75f, 2f));
            done = false;
        }
    }

    IEnumerator Drop(float wait, float wait2, float wait3)
    {
        yield return new WaitForSeconds(wait);
        player.GetComponent<trajectoryScript>().grab = false;
        stay = false;
        yield return new WaitForSeconds(wait2);
        goingUp = true;
        yield return new WaitForSeconds(wait2);
        goingUp = false;
        done = true;
        transform.position = pos;
    }
    IEnumerator Retrieve(float wait, float wait2, float wait3)
    {
        yield return new WaitForSeconds(wait);
        transform.position = new Vector2(player.transform.position.x, transform.position.y);
        goingDown = true;
        stay = false;
        yield return new WaitForSeconds(wait2);
        goingDown = false;
        goingUp = true;
        yield return new WaitForSeconds(wait3);
        goingDown = false;
        goingUp = false;
        stay = true;
    }

    void Down()
    {
        goingUp = false;
        stay = false;
    }
    
    void Up()
    {
        goingDown = false;
        stay = false;
    }

    public void Stay()
    {
        transform.position = transform.position;

        goingDown = false;
        goingUp = false;
    }
}
