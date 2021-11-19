using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTakeDamage : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyShooterGuard();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentHealth -= 25;
        }
    }
    public void DestroyShooterGuard()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
