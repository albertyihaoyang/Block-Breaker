using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int brickableCount = 0;
    private bool isBreakable;
    public GameObject smoke;

    public AudioClip crack;
    private int timesHit;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            brickableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col){
        if (isBreakable){
            HandleHits();
        }
    }

    void HandleHits(){
        timesHit++;
        if (timesHit > hitSprites.Length)
        {
            brickableCount--;
            if (brickableCount <= 0){
                levelManager.LoadNextLevel();
            }
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites(){
        int spritIndex = timesHit - 1;
        if (hitSprites[spritIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spritIndex];
        }
    }
}
