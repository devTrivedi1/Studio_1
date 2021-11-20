using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
	[SerializeField] GameObject playerR;
	// Start is called before the first frame update
	void Start()
	{
		playerR = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			playerR.transform.position = new Vector3(-60.5f, 1.7f, -57.2f);
		}
	}
}
