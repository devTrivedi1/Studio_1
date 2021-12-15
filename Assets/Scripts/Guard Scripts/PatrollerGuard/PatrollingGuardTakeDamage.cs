using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrollingGuardTakeDamage : MonoBehaviour
{
    public float patrollerCurrentHealth;
    public float patrollerMaxHealth;

    public AudioSource guardDeathScream;
    public AudioClip guardDeathScreamClip;


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
        }
        if (collision.gameObject.tag == "EnemyArrow")
        {
            patrollerCurrentHealth -= 5;
            Destroy(collision.gameObject);
        }
    }
    public void DestroyPatrollingGuard()
    {
        if(patrollerCurrentHealth <= 0)
        {
            guardDeathScream.PlayOneShot(guardDeathScreamClip);
            Destroy(this.gameObject, 1);
        }
    }
}
