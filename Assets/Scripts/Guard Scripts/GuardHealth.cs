using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuardHealth : MonoBehaviour
{
     public int health;


    // Start is called before the first frame update
    private void Awake()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health -= 10;
            Debug.Log("enemy health is " + health);
            if(health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("you killed the enemy");
            }
        }
        if(collision.gameObject.tag == "EnemyArrow")
        {
            health -= 5;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
 
}
