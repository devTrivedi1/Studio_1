using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoDamage : MonoBehaviour
{
    private GameObject thePlayer;
    private Rigidbody rb;

    public float currentDamage;
    public float maxDamage;
    public int damageMultiplier;

    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;

    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        rb = thePlayer.GetComponent<Rigidbody>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        if (Input.GetMouseButtonUp(0))
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            for (int i = 0; i < enemies.Length; i++)
            {
                if (explosionRadius >= Vector3.Distance(transform.position, enemies[i].transform.position))
                {
                    var enemyHealth = enemies[i].GetComponent<GuardTakeDamage>();
                    //enemyHealth.health -= currentDamage;
                    
                }
            }
            currentDamage = 0;
           
        }
    }
}
