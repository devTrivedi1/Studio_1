using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoDamage : MonoBehaviour
{
    private GameObject thePlayer;
    private Rigidbody rb;
    public PlayerMovement playerMovement;

    public GameObject[] shooterGuards;
    public GameObject[] chaserGuards;
    public GameObject[] patrollingGuards;

    public float currentDamage;
    public float maxDamage;
    public int damageMultiplier;

    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;

   

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        rb = thePlayer.GetComponent<Rigidbody>();
        playerMovement = thePlayer.GetComponent<PlayerMovement>();

        shooterGuards = GameObject.FindGameObjectsWithTag("ShooterGuard");
        chaserGuards = GameObject.FindGameObjectsWithTag("ChaserGuard");
        patrollingGuards = GameObject.FindGameObjectsWithTag("PatrollingGuard");
    }

    // Update is called once per frame
    void Update()
    {
        ChargeDamage();
        ReleaseDamage();
    }
    public void ChargeDamage()
    {
        if (Input.GetMouseButton(0))
        {
            currentDamage += Time.deltaTime * damageMultiplier;
            if(currentDamage > maxDamage)
            {
                currentDamage = maxDamage;
            }
        }
    }
    public void ReleaseDamage()
    {
        if (playerMovement.playerClicked)
        {
          
            float y = rb.velocity.y;
            y = 0;
            Debug.Log("u go boom");
            for (int i = 0; i < shooterGuards.Length; i++)
            {
                if (explosionRadius >= Vector3.Distance(transform.position, shooterGuards[i].transform.position))
                {
                    var shooterGuard = shooterGuards[i].GetComponent<ShooterGuardTakeDamage>();
                    shooterGuard.shooterCurrentHealth -= currentDamage;

                    var shooterGuardRb = shooterGuards[i].GetComponent<Rigidbody>();
                    shooterGuardRb.AddExplosionForce(explosionForce, shooterGuardRb.position, explosionRadius, upwardsModifier);
                   /* shooterGuardRb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
                    if(shooterGuardRb.position.y > 30)
                    {
                        shooterGuardRb.velocity = Vector3.zero;
                    }*/
                }

            }
            for (int i = 0; i < patrollingGuards.Length; i++)
            {
                if (explosionRadius >= Vector3.Distance(transform.position, patrollingGuards[i].transform.position))
                {
                    var patrollingGuard = patrollingGuards[i].GetComponent<PatrollingGuardTakeDamage>();
                    patrollingGuard.patrollerCurrentHealth -= currentDamage;
                    
                }
            }
            for (int i = 0; i < chaserGuards.Length; i++)
            {
                if (explosionRadius >= Vector3.Distance(transform.position, chaserGuards[i].transform.position))
                {
                    var chaserGuard = chaserGuards[i].GetComponent<ChaserGuardTakeDamage>();
                    chaserGuard.chaserCurrentHealth -= currentDamage;
                    
                }
            }
           


            currentDamage = 0;
           
        }
        else
        {
            playerMovement.playerClicked = false;
        }
        
    }
}
