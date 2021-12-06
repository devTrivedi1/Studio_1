using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGuardTakeDamage : MonoBehaviour
{

	public float chaserCurrentHealth;
	public float chaserMaxHealth;
	// Start is called before the first frame update
	void Start()
	{
		chaserMaxHealth = 100;
		chaserCurrentHealth = chaserMaxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		DestroyChaserGuard();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
		{
			chaserCurrentHealth -= 25;
			Debug.Log("u lost 25 health");
		}
	}
	void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag == "Wall")
		{
			
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Trap Spikes")
		{
			chaserCurrentHealth -= 15;
		}
	}
	public void DestroyChaserGuard()
	{
		if (chaserCurrentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
