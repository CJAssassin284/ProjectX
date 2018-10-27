using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour {
    public bool canGrab = true; //used for player latching onto
    Vector3 shrinkPos = new Vector3(0,0,1);
    Vector3 growPos = new Vector3(.5f, .5f, 1);
    public float timer;
    public trajectoryScript player;
    public bool canDrop = true;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<trajectoryScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.y < (Camera.main.gameObject.transform.position.y - 8))
        {
            Destroy(this.gameObject);
        }

      /*  if (!canGrab)
        {
            timer += Time.deltaTime;
            transform.GetChild(0).localScale = new Vector2(Mathf.Lerp(transform.GetChild(0).localScale.x, shrinkPos.x, Time.deltaTime / 4), Mathf.Lerp(transform.GetChild(0).localScale.y, shrinkPos.y, Time.deltaTime / 4));
            if (timer >= 7)
            {
                if(canDrop)
                player.ExitHolder();
                canGrab = true;
            }
        }
        else if (canGrab && transform.GetChild(0).localScale.x != growPos.x)
        {

            transform.GetChild(0).localScale = new Vector2(Mathf.Lerp(transform.GetChild(0).localScale.x, growPos.x, Time.deltaTime), Mathf.Lerp(transform.GetChild(0).localScale.y, growPos.y, Time.deltaTime));

        }*/
    }
}
