using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
	float dashTime;
	public float startDashTime;
	float direction;
	Rigidbody rb;
    Movement playerPosition;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		dashTime = startDashTime;
	}

	void Update()
	{
	}
}
