using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckPoint : MonoBehaviour
{
	public static CheckPoint instance;
	public Transform respawnPoint;
	public GameObject playerPrefab;

	private void Awake()
	{
		instance = this;
	}

	public void Respawn()
	{
		Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
	}
}
