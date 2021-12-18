using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGuardTakeDamage : MonoBehaviour
{
	public float shooterCurrentHealth;
	public float shooterMaxHealth;

	public AudioSource shooterDeathScream;
	public AudioClip shooterDeathScreamClip;
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
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "EnemyArrow")
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
			shooterDeathScream.PlayOneShot(shooterDeathScreamClip);
			Destroy(this.gameObject, 0.1f);
		}
	}
}
