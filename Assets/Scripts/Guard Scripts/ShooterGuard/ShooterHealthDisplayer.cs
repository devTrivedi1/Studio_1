using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterHealthDisplayer : MonoBehaviour
{
    public ShooterGuardTakeDamage shooterGuard;

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
        DisplayShooterHealth();
    }
    public void DisplayShooterHealth()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = shooterGuard.shooterCurrentHealth / shooterGuard.shooterMaxHealth;
        slider.value = fillValue;

    }
}
