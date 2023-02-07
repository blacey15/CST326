using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public bool isLeftPaddle;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLeftPaddle)
        {
            transform.Translate(0f, Input.GetAxis("Left Paddle") * speed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Translate(0f, Input.GetAxis("Right Paddle") * speed * Time.deltaTime, 0f);
        }
    }

    //  private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log($"we hit {collision.gameObject.name}");

    //     //get reference to paddle collider
    //     BoxCollider bc = GetComponent<BoxCollider>();
    //     Bounds bounds = bc.bounds;
    //     float maxX = bounds.max.x;
    //     float minX = bounds.min.x;
    //     float center = bounds.center.x;

    //     // collision.transform.position.x

    //     Debug.Log($"MaxX = {maxX}, minX = {minX}, center = {center}");
    //     Debug.Log($"{collision.transform.position.x}");
    //     // Debug.Log($"x pos of ball is {}");

    //     //Vector3.Reflect(velocity.normalized, paddle.normal)
    //     reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);

    //     Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);

    //     if(collision.transform.position.x <= maxX)
    //     {
    //         Vector3 bounceDirection = rotation * Vector3.up;
    //     }
    //     else if(collision.transform.position.x >= minX)
    //     {
    //         Vector3 bounceDirection = rotation * Vector3.down;
    //     }
        
        
    //     Rigidbody rb = collision.rigidbody;
    //     // rb.AddForce(bounceDirection * 1000, ForceMode.Force);
    // }
}
