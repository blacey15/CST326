using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 vec;
    public float speed = 4f;
    public Rigidbody rb;
    public Vector3 startPos;

    private AudioSource bounce;
    // Start is called before the first frame update
    void Start()
    {
        bounce = GetComponent<AudioSource>();
        startPos = transform.position;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3 (speed * x, speed * y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        vec = GetComponent<Rigidbody>().velocity;
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPos;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3 (speed * x, speed * y, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float speed2 = vec.magnitude;
        var direction = Vector3.Reflect(vec.normalized, collision.contacts[0].normal);
        GetComponent<Rigidbody>().velocity = direction * speed2;
        bounce.Play();
    }
}
