using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public int CandyMeter;
    int score = 0;
    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        int Score = CandyMeter;
    }
    public void AddPoint() {
        score += 1;
        scoreText.text = score.ToString();
    }

}
