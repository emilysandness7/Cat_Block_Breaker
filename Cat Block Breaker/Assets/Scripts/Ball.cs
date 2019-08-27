using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 50f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cashed component references
    AudioSource  myAudioSource;

	// Use this for initialization
    // calculating distance between the center of the paddle and center of the ball
	void Start () {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();

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

    //play sound whenever ball hits something
    private void OnCollisionEnter2D(Collision2D collision) {
        /*only play sound if game has started.
         Avoids sound playing when ball is resting on paddle.
         Plays a random audio clip from an array of sounds.
         */
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
