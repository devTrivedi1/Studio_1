using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public AudioSource quickDash;
    public AudioClip quickDashClip;

    public AudioSource chargedDash;
    public AudioClip chargedDashClip;

    private void Awake()
    {
        
    }
    void Update()
    {
        if (playerMovement.playerClicked)
        {
            PlaySoundEffects();
        }
    }
    public void PlaySoundEffects()
    {
        if (playerMovement.moveSpeed <= 100)
        {
            quickDash.PlayOneShot(quickDashClip);    
        }
        if (playerMovement.moveSpeed > 100)
        {
            chargedDash.PlayOneShot(chargedDashClip);
        }

    }
}
