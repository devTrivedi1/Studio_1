using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
	[SerializeField] GameObject playerR;
	public Vector3 checkpointPosition = new Vector3(-60.5f, 1.7f, -57.2f);
	// Start is called before the first frame update
	void Start()
	{
		playerR = GameObject.FindGameObjectWithTag("Player");
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			playerR.transform.position = checkpointPosition;
		}
	}
}
