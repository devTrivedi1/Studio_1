using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
	public void RestartGame()
	{
		Debug.Log("Loading Menu");
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Debug.Log("Quitting game");
		Application.Quit();
	}
}
