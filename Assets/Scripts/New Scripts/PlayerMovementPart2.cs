using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPart2 : MonoBehaviour
{

	Rigidbody rb;

	public float speed = 10f;
	private Vector3 targetPos; // To set the target position
	public bool isMoving; //To check if the object moves

	public float forceSpeed = 5f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		targetPos = transform.position;
		isMoving = false;

		

	}

	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			SetTarggetPosition();
		}

		if (isMoving)
		{
			MoveObject();
		}


	}
	void FixedUpdate()
	{

	}
	void SetTarggetPosition()
	{
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if (plane.Raycast(ray, out point))
			targetPos = ray.GetPoint(point);

		isMoving = true;
	}

	void MoveObject()
	{
		transform.LookAt(targetPos);
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

		if (transform.position == targetPos)
			isMoving = false;
		Debug.DrawLine(transform.position, targetPos, Color.red);
	}


}
