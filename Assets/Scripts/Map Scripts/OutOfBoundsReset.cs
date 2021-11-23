using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
	[SerializeField] GameObject playerR;
	private Vector3 checkpointPosition = new Vector3(-390, 2f, -45f);
	// Start is called before the first frame update
	void Start()
	{
		playerR = GameObject.FindGameObjectWithTag("Player");
	}
    /*void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			playerR.transform.position = checkpointPosition;
		}
	}*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
			playerR.transform.position = checkpointPosition;
			playerR.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
