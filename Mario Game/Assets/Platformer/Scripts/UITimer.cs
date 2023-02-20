using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int wholeSecond = (int)Mathf.Floor(Time.realtimeSinceStartup);
        timerText.text = wholeSecond.ToString();
    }
}
