using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoDamage : MonoBehaviour
{
	private GameObject thePlayer;
	private Rigidbody rb;
	public PlayerMovement playerMovement;

	public GameObject[] shooterGuards;
	public GameObject[] chaserGuards;
	public GameObject[] patrollingGuards;
	public GameObject[] shooterSpawnees;//Guards being spawned by patroller guards.

	public float currentDamage;
	public float maxDamage;
	public int damageMultiplier;

	public float explosionForce;
	public float explosionRadius;
	public float upwardsModifier;



	// Start is called before the first frame update
	void Start()
	{
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		rb = thePlayer.GetComponent<Rigidbody>();
		playerMovement = thePlayer.GetComponent<PlayerMovement>();

		shooterGuards = GameObject.FindGameObjectsWithTag("ShooterGuard");
		chaserGuards = GameObject.FindGameObjectsWithTag("ChaserGuard");
		patrollingGuards = GameObject.FindGameObjectsWithTag("PatrollingGuard");
		shooterSpawnees = GameObject.FindGameObjectsWithTag("ShooterSpawnee");

		maxDamage = 25f;
		damageMultiplier = 25;
		explosionForce = 2500f;
		explosionRadius = 20f;
		upwardsModifier = 10f;

	}

	// Update is called once per frame
	void Update()
	{
		ChargeDamage();
		ReleaseDamage();
	}
	public void ChargeDamage()
	{
		if (Input.GetMouseButton(0))
		{
			currentDamage += Time.deltaTime * damageMultiplier;
			if (currentDamage > maxDamage)
			{
				currentDamage = maxDamage;
			}
		}
	}
	public void ReleaseDamage()
	{
		if (playerMovement.playerClicked)
		{

			float y = rb.velocity.y;
			y = 0;
			Debug.Log("u go boom");
			for (int i = 0; i < shooterGuards.Length; i++)
			{
				if (explosionRadius >= Vector3.Distance(transform.position, shooterGuards[i].transform.position))
				{
					var shooterGuard = shooterGuards[i].GetComponent<ShooterGuardTakeDamage>();
					shooterGuard.shooterCurrentHealth -= currentDamage;

					shooterGuard.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position + Vector3.up, explosionRadius);
				}

			}
			for (int i = 0; i < patrollingGuards.Length; i++)
			{
				if (explosionRadius >= Vector3.Distance(transform.position, patrollingGuards[i].transform.position))
				{
					var patrollingGuard = patrollingGuards[i].GetComponent<PatrollingGuardTakeDamage>();
					patrollingGuard.patrollerCurrentHealth -= currentDamage;

					patrollingGuard.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position + Vector3.up, explosionRadius);
				}
			}
			for (int i = 0; i < chaserGuards.Length; i++)
			{
				if (explosionRadius >= Vector3.Distance(transform.position, chaserGuards[i].transform.position))
				{
					var chaserGuard = chaserGuards[i].GetComponent<ChaserGuardTakeDamage>();
					chaserGuard.chaserCurrentHealth -= currentDamage;

					chaserGuard.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position + Vector3.up, explosionRadius);
				}
			}
			for (int i = 0; i < shooterSpawnees.Length; i++)
			{
				if (explosionRadius >= Vector3.Distance(transform.position, chaserGuards[i].transform.position))
				{
					var shooterSpawnee = shooterSpawnees[i].GetComponent<ShooterGuardTakeDamage>();
					shooterSpawnee.shooterCurrentHealth -= currentDamage;

					shooterSpawnee.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position + Vector3.up, explosionRadius);
				}
			}
			currentDamage = 0;
		}
		else
		{
			playerMovement.playerClicked = false;
		}
	}
}
