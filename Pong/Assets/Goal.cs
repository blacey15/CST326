using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;
    private AudioSource horn;

    private void OnTriggerEnter(Collider collision)
    {
        horn = GetComponent<AudioSource>();
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(!isLeftGoal)
            {
                Debug.Log($"Left Player Scored!");
                GameObject.Find("Game Manager").GetComponent<GameManager>().LeftScored();
                horn.Play();
            }
            else
            {
                Debug.Log($"Right Player Scored!");
                GameObject.Find("Game Manager").GetComponent<GameManager>().RightScored();
                horn.Play();
            }
        }
    }
}
