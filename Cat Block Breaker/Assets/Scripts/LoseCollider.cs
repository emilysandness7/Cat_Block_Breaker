using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    //loads the Game_Over scene when ball passes through collider
    private void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene("Game_Over");
    }
}
