using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReleaser : MonoBehaviour
{
    public GameObject attackEnergyBurst;
    public PlayerMovement playerMovement;

    public float currentParticleTimer;
    public float particleTimer;
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
        //MaintainParticlesAngle();

        //StopParticles();
    }
    public void ReleaseParticles()
    {
        if (playerMovement.playerClicked)
        {
            //attackEnergyBurst.SetActive(true);
            attackEnergyBurst.GetComponent<ParticleSystem>().Play();
            //currentParticleTimer += Time.deltaTime;
        }
    }
   /* public void StopParticles()
    {
        if(currentParticleTimer > particleTimer)
        {
            currentParticleTimer = 0;
            attackEnergyBurst.GetComponent<ParticleSystem>().Stop();
        }
    }*/
   /* public void MaintainParticlesAngle()
    {
        attackEnergyBurst.GetComponent<ParticleSystem>().transform.rotation = this.transform.rotation;
    }*/
}
