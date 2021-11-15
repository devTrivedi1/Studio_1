using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseAbility : MonoBehaviour
{
	private float alphaColor = 0.02f;
	private float alphaTimer = 1f;
	private float elapsed;

	public Color originalColor;
	public Color transparentColor;

	private Renderer renderPlayer;


	// Start is called before the first frame update
	void Start()
	{
		renderPlayer = GetComponent<Renderer>();
		originalColor = renderPlayer.material.color;
		transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, alphaColor);

	}

	// Update is called once per frame
	void Update()
	{
		UpdateMaterial();
	}

	void UpdateMaterial()
	{
		elapsed += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Q))
		{
			renderPlayer.material.color = transparentColor;
			if (elapsed >= alphaTimer)
			{
				elapsed = 0f;
				renderPlayer.material.color = originalColor;
				Debug.Log(elapsed);
			}
		}
	}
}
