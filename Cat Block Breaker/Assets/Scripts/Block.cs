using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    //cached references
    Level level;
    GameStatus gameStatus;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        DestroyBlock();
    }

    private void DestroyBlock() {
        //create an AudioSource and play the break sound at Main Camera
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gameStatus.AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
