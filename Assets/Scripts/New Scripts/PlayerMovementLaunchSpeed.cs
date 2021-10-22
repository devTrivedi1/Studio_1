using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementLaunchSpeed : MonoBehaviour
{
	Rigidbody rb;
	float launchSpeed = 50f;

    private float boostCoolDown = 2f;
	private float boostDuration = 3f;

	private bool hasSpeedBoost;
	private Vector3 normalMovement = Vector3.forward;
	private Vector3 currentMovement;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
        currentMovement = normalMovement;
		StartCoroutine(CoolDown());
        

	}

	// Update is called once per frame
	void Update()
	{
		StartCoroutine(CoolDown());
		StartCoroutine(ResetMoveSpeed());

        if(Input.GetMouseButton(1))
        {
            currentMovement += Vector3.forward;
        }

		float x = rb.transform.position.x;
		float y = rb.transform.position.y;
		float z = rb.transform.position.z;
	}

	IEnumerator ResetMoveSpeed()
	{
		//waiting for a few seconds
		yield return new WaitForSeconds(boostDuration);
		//Return to normal
		currentMovement = normalMovement;
		Debug.Log("Boost started at " + currentMovement);
	}

	IEnumerator CoolDown()
	{
		hasSpeedBoost = true;
		yield return new WaitForSeconds(boostCoolDown);
		hasSpeedBoost = false;
		Debug.Log("Boost speed is now" + hasSpeedBoost);
	}
}
