using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyArrow")
        {
            currentHealth -= 5;
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Your health is now " + currentHealth);
        }
      
        if(collision.gameObject.tag == "GuardProjectile")
        {
            rb.velocity = Vector3.zero;
            currentHealth -= 5;
            Debug.Log("your health is " + currentHealth);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap Spikes")
        {
            currentHealth -= 5;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("You hit a spike!");
        }
    }

}
