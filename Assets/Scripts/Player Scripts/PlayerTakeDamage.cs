using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour
{
	public float playerCurrentHealth;
	public float playerMaxHealth;
	private Rigidbody rb;

	void Start()
	{
		playerMaxHealth = 100;
		playerCurrentHealth = playerMaxHealth;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
	
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "EnemyArrow")
		{
			playerCurrentHealth -= 8;
			Destroy(collision.gameObject);
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
		}

		if (collision.gameObject.tag == "GuardProjectile")
		{
			rb.velocity = Vector3.zero;
			playerCurrentHealth -= 8;
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
		}
		if (collision.gameObject.tag == "ChaserGuard")
		{
			rb.velocity = Vector3.zero;
			playerCurrentHealth -= 12;
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
		}
	}
	private void RespawnPlayer()
	{
		CheckPoint.instance.Respawn();
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Trap Spikes")
		{
			playerCurrentHealth -= 7;
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("You hit a spike!");
		}
	}
}
