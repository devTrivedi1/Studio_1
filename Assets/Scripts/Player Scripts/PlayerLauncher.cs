using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dev, I left in a bunch of Debugs, you can uncomment to see any values you want...
public class PlayerLauncher : MonoBehaviour
{
	Rigidbody rb;
	float holdStartTime;
	//float maxChargeTime = 1.0f;

	public float currentSpeedBoost;
	public float maxSpeedBoost = 50;
	private float speedMultiplier = 100f;//(for the speed boost).
	private float addTheSpeed = 6.5f;
	public float maxSpeed = 150;//(player's speed plus the speed boost).

	private float speedReset = 0.2f;//Time to wait to reset the move speed;

	public PlayerMovement playerMovement;
	private bool playerReachedTarget;
	private Vector3 roomForError = Vector3.one * 10;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		currentSpeedBoost = 50f;
	}

	void Update()
	{
		WhileCharging();
		StartCoroutine("SpeedBoostDuration");
	}

	private void WhileCharging()
	{
		if (Input.GetMouseButton(0))
		{
			currentSpeedBoost += Time.deltaTime * speedMultiplier;//value keeps increasing;
			playerMovement.moveSpeed += currentSpeedBoost * Time.deltaTime * addTheSpeed;//Player speed was increasing way faster than
																						 //the speed boost, because of += I guess. When I added another Time.DeltaTime on the line above that slowed it down. Try to multiply it by 
																						 //different floats and see what happens...

			if (currentSpeedBoost > maxSpeedBoost)
			{
				currentSpeedBoost = maxSpeedBoost; //speed boost won't go higher than the maxSpeedBoost;
			}
		}

		if (playerMovement.moveSpeed >= maxSpeed)
		{
			playerMovement.moveSpeed = maxSpeed;
		}

	}
	public IEnumerator SpeedBoostDuration()
	{
		if (Input.GetMouseButtonUp(0))
		{
			yield return new WaitForSeconds(speedReset);
			currentSpeedBoost = 0;
			playerMovement.moveSpeed = 50f;
		}

	}



}
