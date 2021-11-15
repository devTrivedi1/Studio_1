using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    private int health;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
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
            health -= 5;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Your health is now " + health);
        }
        if(collision.gameObject.tag == "Trap Spikes")
        {
            health -= 5;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("You hit a spike!");
        }
        if(collision.gameObject.tag == "GuardProjectile")
        {
            rb.velocity = Vector3.zero;
            health -= 5;
            Debug.Log("your health is " + health);
        }
    }
}
