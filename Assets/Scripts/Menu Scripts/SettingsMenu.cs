using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer mixer;
    PauseMenu paused;
void Update()
{
    
		if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
}
	public void SetVolume(float volume)
	{
		mixer.SetFloat("Volume", volume);
	}
    
}
