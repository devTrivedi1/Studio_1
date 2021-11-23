using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShoot : MonoBehaviour
{
	public GameObject theProjectile;
	private int startSpawn;
	public float spawnDelay;

	private Vector3 spawnOffset;

	public float shootingRange = 40f;
	public float distanceToPlayer;
	private GameObject thePlayer;
	public bool inShootingRange;

	public float timer;

	public float projectileMoveSpeed;

	public LayerMask layerMask;
	void Start()
	{
		startSpawn = 1;

		spawnOffset = new Vector3(0, 0, 2);
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}


	void Update()
	{
		spawnDelay = 1;
		DetectPlayer();

		timer += Time.deltaTime;
	}

	private void DetectPlayer()
	{
		distanceToPlayer = Vector3.Distance(thePlayer.transform.position, transform.position);
		if (!Physics.Linecast(transform.position, thePlayer.transform.position, layerMask) && distanceToPlayer <= shootingRange)
		{
			inShootingRange = true;
			Debug.Log("Player is in range");
			if (timer >= spawnDelay)
			{
				StartFiring();

			}


		}
		else
		{
			inShootingRange = false;
		}
	}

	public void StartFiring()
	{
		timer = 0;
		GameObject projectile = Instantiate(theProjectile, transform.position + spawnOffset, transform.rotation);
		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		Vector3 shootForce = Vector3.forward * projectileMoveSpeed;
		rb.AddForce(transform.TransformDirection(shootForce), ForceMode.Impulse);

		Rigidbody rbGuard = this.transform.GetComponent<Rigidbody>();
		rbGuard.freezeRotation = true;
	}

}
