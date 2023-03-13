using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class PointManager : MonoBehaviour
{

    public int score;

    public TMP_Text scoreText;
    public AudioSource blowUp;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        blowUp = GetComponent<AudioSource>();
    }

    public void updateScore(int points)
    {
        blowUp.Play();
        score += points;
        scoreText.text = "Score: " + score;
    }
}
