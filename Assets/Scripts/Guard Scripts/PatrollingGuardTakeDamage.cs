using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrollingGuardTakeDamage : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;


    // Start is called before the first frame update
    private void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
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
            currentHealth -= 10;
            Debug.Log("enemy health is " + currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("you killed the enemy");
            }
        }
        if (collision.gameObject.tag == "EnemyArrow")
        {
            currentHealth -= 5;
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void DestroyPatrollingGuard()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
