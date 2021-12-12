using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLunge : MonoBehaviour
{
	private float lungeHeight = 15;
	Rigidbody rb;
	public bool shouldLunge;
	public bool isGrounded;

	public PlayerMovement player;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		isGrounded = true;
	}

	// Update is called once per frame
	void Update()
	{
		ReadInputs();
		CancelLunge();
		MaintainVelocity();
	}
	private void FixedUpdate()
	{

		Lunge();

	}
	public void ReadInputs()
	{
		if (Input.GetMouseButtonUp(1))
		{
			shouldLunge = true;
		}
	}
	public void Lunge()
	{
		float x = 0;
		//float y = lungeHeight;
		//float z = rb.velocity.z;
		float lungeDirection = 30;
		Vector3 lungePower = new Vector3(x, lungeHeight + 3, lungeDirection);
		if (shouldLunge && isGrounded)
		{
			//Debug.Log("you lunged");
			//Debug.Log("your velocity is" + transform.position.y);
			/* rb.AddForce(transform.TransformDirection(lungePower), ForceMode.Impulse); */
			rb.AddForce(transform.TransformDirection(lungePower), ForceMode.Impulse);
			isGrounded = false;
			shouldLunge = false;
			/* Debug.Log("your velocity is " + rb.velocity); */
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
			player.playerClicked = false;
		}
	}
	public void CancelLunge()
	{
		if (shouldLunge && isGrounded == false)
		{
			shouldLunge = false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "LungePanel")
		{
			isGrounded = true;
		}
	}
	public void MaintainVelocity()
	{
		Vector3 velocity = rb.velocity;
		if (velocity.x < 0)
		{
			velocity.x = 0;
		}
		if (velocity.z < 0)
		{
			velocity.z = 0;
		}
	}
}
