using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 50f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;

	// Use this for initialization
    // calculating distance between the center of the paddle and center of the ball
	void Start () {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        //if mouse has not been clicked, lock it to paddle and check for click
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    //lauches ball off paddle on left mouse click
    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2( xPush, yPush);
        }
    }

    // ball's position is where the paddle is plus the distance between the ball and paddle midpoints
    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        this.transform.position = paddlePos + paddleToBallVector;
    }
}
