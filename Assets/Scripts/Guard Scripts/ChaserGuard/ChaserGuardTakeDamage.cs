using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGuardTakeDamage : MonoBehaviour
{
    public float chaserCurrentHealth;
    public float chaserMaxHealth;

    void Start()
    {
        chaserMaxHealth = 100;
        chaserCurrentHealth = chaserMaxHealth;
    }

    void Update() => DestroyChaserGuard();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
            chaserCurrentHealth -= 8;

        if (collision.gameObject.tag == "Player")
            Destroy(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap Spikes")
            chaserCurrentHealth -= 15;
    }
    public void DestroyChaserGuard()
    {
        if (chaserCurrentHealth <= 0)
            Destroy(this.gameObject);
    }
}