using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]


public class Movement : MonoBehaviour
{
	public float speed;

	Vector3 targetPos;
	bool isMoving = false;

	void Update()
	{

		if (Input.GetButtonDown("Fire1"))
		{
			TargetPosition();
            Debug.Log("Left click enabled");
		}
		if (isMoving)
		{
			Move();
		}

	}

	void TargetPosition()
	{
		targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPos.z = transform.position.z;
		isMoving = true;
        Debug.Log("TargetPosition");
	}

	void Move()
	{

		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		if (transform.position == targetPos)
		{
			isMoving = false;
            Debug.Log("Move Function");
		}
	}
}
