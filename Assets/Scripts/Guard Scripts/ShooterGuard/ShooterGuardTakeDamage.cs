using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGuardTakeDamage : MonoBehaviour
{
	public float shooterCurrentHealth;
	public float shooterMaxHealth;
	// Start is called before the first frame update
	void Start()
	{
		shooterMaxHealth = 200;
		shooterCurrentHealth = shooterMaxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		DestroyShooterGuard();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			shooterCurrentHealth -= 25;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Trap Spikes")
		{
			shooterCurrentHealth -= 15;
		}
	}
	public void DestroyShooterGuard()
	{
		if (shooterCurrentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
