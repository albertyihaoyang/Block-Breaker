﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
    }

    void AutoPlay(){
        Vector3 ballPos = ball.transform.position;
        this.transform.position = new Vector3(Mathf.Clamp(ballPos.x, 0.5f, 15.5f), 0.5f, 0f);
    }

    void MoveWithMouse(){
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), 0.5f, 0f);
    }
}
