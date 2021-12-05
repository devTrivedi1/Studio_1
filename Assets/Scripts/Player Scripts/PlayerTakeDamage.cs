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

	// Start is called before the first frame update
	void Start()
	{
		playerMaxHealth = 100;
		playerCurrentHealth = playerMaxHealth;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "EnemyArrow")
		{
			playerCurrentHealth -= 5;
			Destroy(collision.gameObject);
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			//Debug.Log("Your health is now " + playerCurrentHealth);
		}
		
		if (collision.gameObject.tag == "GuardProjectile")
		{
			rb.velocity = Vector3.zero;
			playerCurrentHealth -= 10;
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			//Debug.Log("your health is " + playerCurrentHealth);
		}
		if (collision.gameObject.tag == "GuardChaser")
		{
			rb.velocity = Vector3.zero;
			playerCurrentHealth -= 25;
			if (playerCurrentHealth <= 0)
			{
				//Destroy(gameObject);
				RespawnPlayer();
			}
			//Debug.Log("your health is " + playerCurrentHealth);
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
			playerCurrentHealth -= 5;
			if (playerCurrentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("You hit a spike!");
		}
	}
}
