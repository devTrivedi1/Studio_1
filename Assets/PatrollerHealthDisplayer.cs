using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrollerHealthDisplayer : MonoBehaviour
{
    public PatrollingGuardTakeDamage patrollerGuard;

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
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = patrollerGuard.currentHealth / patrollerGuard.maxHealth;
        slider.value = fillValue;

    }
}
