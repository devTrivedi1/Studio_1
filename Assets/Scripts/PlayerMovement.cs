using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector3 targetPosition;
	Vector3 lookAtTarget;
	public bool playerClicked;
	Quaternion playerRot;
	public int rotSpeed;
	public int moveSpeed;
	public Vector3 offset;
	public float speedforce = 100f;
	Rigidbody rb;
	float holdStartTime;
    Transform forceTransform;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			playerClicked = true;
			SetTargetPosition();
		}
		if (Input.GetMouseButtonUp(0))
		{
			playerClicked = true;
			SetTargetPosition();
			float holdDownTime = Time.time - holdStartTime;
			Launch(HoldDownForce(holdDownTime));
		}
		// if (Input.GetMouseButtonUp(0))
		// {
		//     playerClicked = false;
		//}

	}
	private void Launch(float force)
	{
        rb.position = transform.position;
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 1f;
        rb.velocity = direction * force;
	}
	private float HoldDownForce(float holdTime)
	{
		float maxForceHoldTime = 3f;
		float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
		float force = holdTimeNormalized * speedforce;
        return force;
	}

	private void FixedUpdate()
	{
		if (playerClicked)
		{
			Move();
			playerClicked = false;
		}

	}
	public void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000))
		{
			targetPosition = hit.point;
			Debug.Log(targetPosition);
			//this.transform.LookAt(targetPosition);
			lookAtTarget = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y,
				targetPosition.z - transform.position.z);
			playerRot = Quaternion.LookRotation(lookAtTarget);

		}
	}
	public void Move()
	{

		transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition + offset, moveSpeed * Time.deltaTime);
	}
}
