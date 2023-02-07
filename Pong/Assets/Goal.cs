using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(!isLeftGoal)
            {
                Debug.Log($"Left Player Scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().LeftScored();
            }
            else
            {
                Debug.Log($"Right Player Scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().RightScored();
            }
        }
    }
}
