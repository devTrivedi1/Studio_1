using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
	public Rigidbody rb;
	public float dashForce;

	public float dashSpeed;
	public float curretDashTimer;
	public float dashTimer;
	public float dashDistance;
	public Vector3 dashDirection;

	public bool isDashing;
	public bool hasDashed;

	private float dashCoolDown;
	public float dashCoolDownReset;

	public AudioSource dashing;
	public AudioClip dashingClip;

	private PlayerMovement playerMovement;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		dashing.loop = false;

		dashCoolDown = dashCoolDownReset;
		curretDashTimer = dashTimer;

		dashForce = 2;
		dashSpeed = 80f;

		dashTimer = 2f;
		dashDistance = 30f;

		playerMovement = GetComponent<PlayerMovement>();
	}


	void Update()
	{
		Dash();
		DashReset();
		MaintainDash();
	}

	public void Dash()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Vector3 forwardDash = Vector3.forward;
			isDashing = true;
			if (isDashing)
			{
				rb.velocity = transform.TransformDirection(forwardDash * dashSpeed);
				hasDashed = true;
                if (!dashing.isPlaying)
                {
					dashing.clip = dashingClip;
					dashing.Stop();
					dashing.Play();

				}
			}
		}
	}
	public void DashReset()
	{

		if (isDashing)
		{
			curretDashTimer -= Time.deltaTime;

		}
		if (curretDashTimer <= 0)
		{
			isDashing = false;
			curretDashTimer = dashTimer;
		}

	}

	public void MaintainDash()
	{
		if (isDashing)
		{
			playerMovement.enabled = false;
		}
		else if (hasDashed)
		{
			playerMovement.enabled = true;
			this.enabled = false;
		}
	}
}
