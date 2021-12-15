using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	GameObject player;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Start()
	{
		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "Level_2")
		{	
			player.GetComponent<Invisibilty>().enabled = true;
		}
		if(scene.name == "Level_3")
		{
			player.GetComponent<PlayerDash>().enabled = true;
			player.GetComponent<PlayerPhase>().enabled = true;
		}
		if (scene.name == "Level_4")
		{
			player.GetComponent<PlayerLunge>().enabled = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

	}

}
