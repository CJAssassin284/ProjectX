using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ActionCode2D.Renderers;

public class Combo : MonoBehaviour {
    public float timer;
    public int comboNumber = 1;
    bool startCombo;
    bool red;
    bool blue;
    bool threw;
    public static Combo instance;
    trajectoryScript trajectoryScript;
    public Text scoreTxt;
    public int score;
    int lastScore;
    Color color;
    public Controller controller;
    public GameObject[] holder;
    public Vector3 min, max;
    bool fire;
    GameObject col;
	// Use this for initialization
	void Start () {
        instance = this;
        trajectoryScript = GetComponent<trajectoryScript>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreTxt.text = score.ToString();

        if (startCombo)
            timer += Time.deltaTime;
        
        if(timer >= 7)
        {
            startCombo = false;
            comboNumber = 1;
            timer = 0;
        }
        if(trajectoryScript.ballIsClicked2)
        {
            threw = false;
        }
        if(score >= lastScore + 10)
        {
          //  controller.DoPower();
            lastScore = score;
        }

        if(comboNumber >= 3 && fire == false)
        {
            gameObject.GetComponent<SpriteGhostTrailRenderer>().enabled = false;

            fire = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Holder"))
        {
            if(col != collision.gameObject)
            Instantiate(holder[Random.Range(0,holder.Length)], new Vector3(Random.Range(min.x, max.x), collision.transform.position.y + 3, transform.position.z), Quaternion.identity);
            col = collision.gameObject;

            

        }
        if (collision.CompareTag("Red"))
        {
            GetColor();
            collision.GetComponent<SpriteRenderer>().color = color;
            GetComponent<SpriteRenderer>().color = color;
            red = true;
            blue = false;
            threw = true;
        }
        if (collision.CompareTag("Blue"))
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            blue = true;
            red = false;
            threw = true;
        }
    }

    void GetColor()
    {
        color = new Color(
    Random.Range(0f, 1f),
    Random.Range(0f, 1f),
    Random.Range(0f, 1f)
);
        
    }

    public void SpeedSpawn(Transform pos)
    {
        Instantiate(holder[0], new Vector3(pos.transform.position.x, pos.transform.position.y + 10, transform.position.z), Quaternion.identity);

    }
}
