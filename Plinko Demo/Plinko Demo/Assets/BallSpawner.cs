using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    // Start is called before the first frame update
    // void Start()
    // {
    //     Vector3 spawnPos = GetComponent<Transform>().position;
    //     Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = new Vector3(Random.Range(0, 21), 5, 0);
            // Vector3 spawnPos = GetComponent<Transform>().position;
            Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        }
    }
}
