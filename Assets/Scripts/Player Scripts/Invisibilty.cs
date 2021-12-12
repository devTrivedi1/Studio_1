using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilty : MonoBehaviour
{
    public GameObject currentGameObject;
    private Material mat;
    private float alphaVal;

    public float timer = 2f;
    private float currentTimer;

    public bool isInvisible;
    private Color myColour;
    private Material playerMat;


  
    void Start()
    {
        currentGameObject = gameObject;
        currentTimer = timer;
        myColour = currentGameObject.GetComponent<Renderer>().material.color;
    

    }

  
    void Update()
    {
        InvisibiltyTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Invisible")
        {
            isInvisible = true;
            alphaVal = 0.25f;
            currentTimer = timer;

            currentGameObject.GetComponent<Renderer>().material.color = Color.white;
            currentGameObject.layer = LayerMask.NameToLayer("Invisible");

            other.gameObject.SetActive(false);
        }
    }
   
    public void InvisibiltyTimer()
    {
        if (isInvisible)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            { 
                currentGameObject.GetComponent<Renderer>().material.color = myColour;
                isInvisible = false;
                  currentGameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
    }

}
