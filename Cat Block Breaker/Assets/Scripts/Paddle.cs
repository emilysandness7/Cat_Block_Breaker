using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] int screenUnits = 16;
    [SerializeField] float screenMinUnits = 1f;
    [SerializeField] float screenMaxUnits = 15f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Gets the mouse's x position and does math so it is contained in the screen
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenUnits;

        // Moves the paddle to the mouse's x location
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        //mathf.clamp limits the x movement of the paddle, paddle cannot go offscreen
        paddlePos.x = Mathf.Clamp(mousePosInUnits, screenMinUnits, screenMaxUnits);
        transform.position = paddlePos;
	}
}
