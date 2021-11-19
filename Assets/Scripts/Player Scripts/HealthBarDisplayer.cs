using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplayer : MonoBehaviour
{
    public PlayerTakeDamage thePlayer;

    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
    }
    public void DisplayHealth()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = thePlayer.currentHealth / thePlayer.maxHealth;
        slider.value = fillValue;
       
    }
}
