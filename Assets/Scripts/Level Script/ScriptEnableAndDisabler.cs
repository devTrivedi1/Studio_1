using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptEnableAndDisabler : MonoBehaviour
{
	bool InvisiblityUnlocked = false;
	public Invisibilty getInvisibleScript;

	void Start()
	{

	}

	void Update()
	{
		DisableScript();
		CheckForInvisiblity();
	}

	void DisableScript()
	{
		if (InvisiblityUnlocked == false)
		{
			getInvisibleScript = GetComponent<Invisibilty>();
			getInvisibleScript.enabled = false;
			Scene scene_1 = SceneManager.GetSceneAt(1);
			Scene scene_2 = SceneManager.GetSceneAt(2);
		}

	}
	void CheckForInvisiblity()
	{
		if (!InvisiblityUnlocked)
		{
			InvisiblityUnlocked = true;
			Scene scene_3 = SceneManager.GetSceneAt(3);
			getInvisibleScript = GetComponent<Invisibilty>();
			getInvisibleScript.enabled = true;
		}
	}
}
