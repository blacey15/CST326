using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float acceleration = 10f; 
	public float maxSpeed = 3f;
	public float jumpForce = 10f;
	public float jumpBoost = 5f;
	public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
		Rigidbody rbody = GetComponent<Rigidbody>();
		rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;

		Collider col = GetComponent<Collider>();
		float halfHeight = col.bounds.extents.y + 0.03f;

		isGrounded = Physics.Raycast(transform.position, Vector3.down, halfHeight);

		rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed),rbody.velocity.y, rbody.velocity.z);

		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
		}
    }
}
