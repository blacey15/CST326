using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer;
    public bool timerOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                updateTime(ref timer);
            }
        }
        //int wholeSecond = (int)Mathf.Floor(Time.realtimeSinceStartup);
        //timerText.text = wholeSecond.ToString();
    }

    void updateTime(ref float current)
    {
        //current -= 1;
        float seconds = Mathf.FloorToInt(current);
        timerText.text = (($"{seconds}"));
    }
}
