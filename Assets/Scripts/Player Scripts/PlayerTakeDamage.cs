using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour
{
	public float currentHealth;
	public float maxHealth;
	private Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		maxHealth = 100;
		currentHealth = maxHealth;
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
			currentHealth -= 5;
			Destroy(collision.gameObject);
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("Your health is now " + currentHealth);
		}
		if (collision.gameObject.tag == "Trap Spikes")
		{
			currentHealth -= 5;
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("You hit a spike!");
		}
		if (collision.gameObject.tag == "GuardProjectile")
		{
			rb.velocity = Vector3.zero;
			currentHealth -= 10;
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("your health is " + currentHealth);
		}
		if (collision.gameObject.tag == "GuardChaser")
		{
			rb.velocity = Vector3.zero;
			currentHealth -= 25;
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
				RespawnPlayer();
			}
			Debug.Log("your health is " + currentHealth);
		}
	}

	private void RespawnPlayer()
	{
		CheckPoint.instance.Respawn();
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}

}
