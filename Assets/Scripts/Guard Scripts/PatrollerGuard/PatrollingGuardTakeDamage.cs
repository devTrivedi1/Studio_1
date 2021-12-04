using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrollingGuardTakeDamage : MonoBehaviour
{
    public float patrollerCurrentHealth;
    public float patrollerMaxHealth;


    // Start is called before the first frame update
    private void Awake()
    {
        patrollerMaxHealth = 100;
        patrollerCurrentHealth = patrollerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyPatrollingGuard();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            patrollerCurrentHealth -= 10;
            Debug.Log("enemy health is " + patrollerCurrentHealth);
            if (patrollerCurrentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("you killed the enemy");
            }
        }
        if (collision.gameObject.tag == "EnemyArrow")
        {
            patrollerCurrentHealth -= 5;
            Destroy(collision.gameObject);
            if (patrollerCurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void DestroyPatrollingGuard()
    {
        if(patrollerCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
