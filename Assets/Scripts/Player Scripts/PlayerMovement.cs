using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Vector3 targetPosition;
	public Vector3 lookAtTarget;
	public bool playerClicked;
	Quaternion playerRot;
	public float moveSpeed = 50f;
	private Vector3 offset = new Vector3(0, 1.5f, 0);

	public Vector3 newPosition;
	public LayerMask layerMask;

	private Rigidbody rb;

	public PlayerLauncher playerLauncher;
	public PlayerLunge playerLunge;
	//Transform forceTransform;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		playerLauncher = GetComponent<PlayerLauncher>();
		playerLunge = GetComponent<PlayerLunge>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonUp(0))
		{
			playerClicked = true;
			SetTargetPosition();
		}
		Debug.Log(rb.velocity);
	}


	private void FixedUpdate()
	{
		if (playerClicked)
		{
			Move();
			/* ReleaseDamage(); */
		}

	}
	public void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000, layerMask))
		{
			targetPosition = hit.point;
			//Debug.Log("target pos is " + targetPosition);
			//this.transform.LookAt(targetPosition);
			lookAtTarget = 
			new Vector3(targetPosition.x - transform.position.x, 
			targetPosition.y - transform.position.y,
			targetPosition.z - transform.position.z) * Time.fixedDeltaTime;
			playerRot = Quaternion.LookRotation(lookAtTarget);

		}

	}


	public void Move()
	{

		/* rb.velocity = (targetPosition - this.transform.position) * moveSpeed * Time.fixedDeltaTime; */

		if (playerLunge.isGrounded == false)
		{
			Vector3 direction = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);
			rb.velocity = direction * (moveSpeed * Time.deltaTime);
		}
		else
		{
			Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);
			rb.velocity = direction * (moveSpeed * Time.deltaTime);
		}


		if (transform.position == targetPosition)
		{
			rb.velocity = Vector3.zero;
		}

		/* rb.velocity = Vector3.MoveTowards(this.transform.position, targetPosition + offset, moveSpeed * Time.deltaTime); */
		/* transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, moveSpeed * Time.deltaTime); */
		//newPosition = Vector3.MoveTowards(transform.position, targetPosition + offset, moveSpeed * Time.deltaTime);
		//transform.position = newPosition;
	}
	public void ReleaseDamage()
	{
		rb.AddExplosionForce(10, new Vector3(10, 10, 10), 10, 1, ForceMode.Impulse);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			rb.velocity = Vector3.zero;
		}
		if (collision.gameObject.tag == "TrapPanel")
		{
			rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
		}
	}
	/*  private void OnCollisionExit(Collision collision)
	  {
		  if(collision.gameObject.tag == "TrapPanel")
		  {
			  Destroy(collision.gameObject);
		  }
	  }*/
}
