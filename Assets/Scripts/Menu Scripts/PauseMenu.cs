using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool gamePaused = false;
	public GameObject pauseMenuUI;
	public GameObject healthBar;
	RotationalMovement player; 
	// Update is called once per frame
	void Awake()
	{
		healthBar = GameObject.FindGameObjectWithTag("HealthBar");
		player = FindObjectOfType<RotationalMovement>();
	}
	void Update()
	{


		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused)
			{
				Resume();
				healthBar.SetActive(true);
			}
			else
			{
				Pause();
				healthBar.SetActive(false);
			}
		}
		if(gamePaused == true && GetComponent<SettingsMenu>().isActiveAndEnabled)
		{
			Time.timeScale = 0f;
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		healthBar.SetActive(true);
		Time.timeScale = 1f;
		gamePaused = false;
		player.enabled = true;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		healthBar.SetActive(false);
		Time.timeScale = 0f;
		gamePaused = true;
		player.enabled = false;
	}

	public void LoadMenu()
	{
		Debug.Log("Loading Menu");
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Debug.Log("Quitting game");
		Application.Quit();
	}
}