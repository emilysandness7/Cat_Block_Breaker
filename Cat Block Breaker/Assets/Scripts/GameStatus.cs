using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    //configuration parameters
    [Range(0.1f, 3f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //state variables
    [SerializeField] int currentScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
       
    }

    //takes the current score and displays it on the screen
    private void UpdateScoreText() {
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
        UpdateScoreText();
    }
}
