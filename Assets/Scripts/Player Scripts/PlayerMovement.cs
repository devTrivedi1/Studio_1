using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Vector3 targetPosition;
	public Vector3 lookAtTarget;
	public bool playerClicked;
	Quaternion playerRot;
	public float moveSpeed;
	private Vector3 offset = new Vector3(0, 1.5f, 0);

	public Vector3 newPosition;
	public LayerMask layerMask;

	private Rigidbody rb;

	public PlayerLauncher thePlayer;
	//Transform forceTransform;

	// Start is called before the first frame update
	void Start()
	{
		moveSpeed = 150f;
		rb = GetComponent<Rigidbody>();

		thePlayer = GetComponent<PlayerLauncher>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonUp(0))
		{
			playerClicked = true;
			SetTargetPosition();
		}
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
			lookAtTarget = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y,
				targetPosition.z - transform.position.z) * Time.fixedDeltaTime;
			playerRot = Quaternion.LookRotation(lookAtTarget);

		}

	}


	public void Move()
	{

		/* rb.velocity = (targetPosition - this.transform.position) * moveSpeed * Time.fixedDeltaTime; */
		Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);
		rb.velocity = direction * thePlayer.currentSpeedBoost;
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
}
