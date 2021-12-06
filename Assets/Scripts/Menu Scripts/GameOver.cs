using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	GameObject buttons;
    [SerializeField] GameObject deathPanel;
    public Animator deathAnimationScreen;
	PlayerTakeDamage playerDeath;
	public Animator animate;
	
	void Start()
	{
        animate = gameObject.GetComponent<Animator>();
		buttons = GameObject.FindGameObjectWithTag("GameOverButton");
		buttons.SetActive(false);

	}

	void Update()
	{
		if (playerDeath.playerCurrentHealth <= 0)
		{
            deathPanel.SetActive(true);
            deathAnimationScreen.StartPlayback();
			buttons.SetActive(true);
			animate.SetTrigger("Buttons");

		}
	}
}
