using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached references
    Level level;
    GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit; //TODO onyl serialized for debug purposes

    private void Start() {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") { //only destroy block if breakable
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") { //only destroy block if breakable
            HandleHit();
        }
    }

    //if breakable block is hit, increment times hit and check if it can be destroyed
    private void HandleHit() {
        timesHit++;
        if (timesHit >= maxHits) { //destroy block only if block has been hit enough times
            DestroyBlock();
        }
        else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }


    /* Destroys block when called.
     * First plays breaking sound on main camera
     * Then instantiates sparkle particle effect.
     * Then adds to score.
     * Then destroys the block GameObject.
     * Then calls BlocksDestroyed which subtracts blocks in world count.
     * */
    private void DestroyBlock() {

            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            TriggerSparklesVFX();
            gameStatus.AddToScore();
            Destroy(gameObject);
            level.BlockDestroyed();
        
    }

    //instantiates a sparkle particle effect, particle effect is destroyed in hierarchy after 2 seconds
    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
