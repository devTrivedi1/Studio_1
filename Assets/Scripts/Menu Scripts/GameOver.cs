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
	// Start is called before the first frame update
	void Start()
	{
        animate = gameObject.GetComponent<Animator>();
		buttons = GameObject.FindGameObjectWithTag("GameOverButton");
		buttons.SetActive(false);

	}

	// Update is called once per frame
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
