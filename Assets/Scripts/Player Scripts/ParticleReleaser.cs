using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReleaser : MonoBehaviour
{
    public GameObject attackEnergyBurst;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        attackEnergyBurst = GameObject.FindGameObjectWithTag("AttackBurst");
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseParticles();
    }
    public void ReleaseParticles()
    {
        if (playerMovement.playerClicked)
        {
            attackEnergyBurst.GetComponent<ParticleSystem>().Play();
        }
    }
}
