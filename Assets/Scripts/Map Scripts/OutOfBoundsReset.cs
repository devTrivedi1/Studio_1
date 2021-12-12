using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
	[SerializeField] GameObject playerR;
	public Vector3 checkpointPosition = new Vector3(-449.9f, 2f, -54.8f);
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
