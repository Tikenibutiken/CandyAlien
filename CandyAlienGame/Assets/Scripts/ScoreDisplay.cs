using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Grow player; // reference to the PlayerGrow script

    private Text scoreText; // text object to display the score

    void Start()
    {
        // get the Text component attached to this object
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        // update the score displayed in the text object
        scoreText.text = "Score: " + player.score;
    }
}