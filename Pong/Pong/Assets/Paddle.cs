using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isLeftPaddle;
    public float unitsPerSecond = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // float horizontalValue = Input.GetAxis("Horizontal");
        // Vector3 force = Vector3.right * horizontalValue; //* unitsPerSecond * Time.deltaTime;

        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if(isLeftPaddle)
        {
            transform.Translate(0f, Input.GetAxis("Left Paddle") * unitsPerSecond * Time.deltaTime, 0f);
        }
        else
        {
            transform.Translate(0f, Input.GetAxis("Right Paddle") * unitsPerSecond * Time.deltaTime, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"we hit {collision.gameObject.name}");

        //get reference to paddle collider
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;

        // Debug.Log($"MaxX = {maxX}, minX = {minX}");
        // Debug.Log($"x pos of ball is {}");

        Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);
        Vector3 bounceDirection = rotation * Vector3.up;
        
        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 1000, ForceMode.Force);
    }
}
