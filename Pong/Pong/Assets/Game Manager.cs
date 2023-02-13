using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    public GameObject LeftPaddle;
    public GameObject LeftGoal;

    public GameObject RightPaddle;
    public GameObject RightGoal;

    public GameObject LeftText;
    public GameObject RightText;

    private int LeftScore;
    private int RightScore;

    public void LeftScored()
    {
        LeftScore++;
        LeftText.GetComponent<TextMeshProUGUI>().text = LeftScore.ToString();
        ResetPos();
    }
    public void RightScored()
    {
        RightScore++;
        RightText.GetComponent<TextMeshProUGUI>().text = RightScore.ToString();
        ResetPos();
    }
    private void ResetPos(){
        ball.GetComponent<Ball>().Reset();
    }
}
