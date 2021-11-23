using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilty : MonoBehaviour
{
    public GameObject currentGameObject;
    private Material mat;//material of the player.
    private float alphaVal;//The level of transparency or 'invisibilty' we want for the player.

    public float timer = 2f;
    private float currentTimer;

    public bool isInvisible;
    private Color myColour;
    private Material playerMat;


    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
        currentTimer = timer;
        myColour = currentGameObject.GetComponent<Renderer>().material.color;
    

    }

    // Update is called once per frame
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

            //ChangeAlpha(currentGameObject.GetComponent<Renderer>().material, alphaVal);
            currentGameObject.GetComponent<Renderer>().material.color = Color.white;
            currentGameObject.layer = LayerMask.NameToLayer("Invisible");

            other.gameObject.SetActive(false);

        }

    }
    /*public void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);


    }*/
    /*private void OnTriggerExit(Collider other)
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {

            currentGameObject.GetComponent<Renderer>().material.color = mat.color;
        }

    }*/
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
    /*public void RevertAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);


    }*/



}
