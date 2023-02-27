using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float acceleration = 10f; 
	public float maxSpeed = 3f;
	public float jumpForce = 10f;
	public float jumpBoost = 5f;
	public bool feetOnGround = false;
	
    void Update()
    {
	    Bounds bounds = GetComponent<Collider>().bounds;
	    feetOnGround = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y + 0.1f);
	    
        var axis = Input.GetAxis("Horizontal");
		Rigidbody rbody = GetComponent<Rigidbody>();
		rbody.AddForce(Vector3.right * axis * acceleration, ForceMode.Force);
		
		if(feetOnGround && Input.GetKeyDown(KeyCode.Space))
		{
			rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		else if (Input.GetKey(KeyCode.Space))
		{
			rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
		}
		
		float xVelocity = Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed);

		if (Mathf.Abs(axis) < 0.1f)
		{
			xVelocity *= 0.9f;
		}

		rbody.velocity = new Vector3(xVelocity, rbody.velocity.y, rbody.velocity.z);

		float speed = rbody.velocity.magnitude;

		Animator animator = GetComponent<Animator>();
		animator.SetFloat("Speed", speed);
		animator.SetBool("Jumping", !feetOnGround);

		Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.1f, true);

		//isGrounded = Physics.Raycast(transform.position, Vector3.down, halfHeight);
		//Collider col = GetComponent<Collider>();
		//float halfHeight = col.bounds.extents.y + 0.03f;
    }
}
