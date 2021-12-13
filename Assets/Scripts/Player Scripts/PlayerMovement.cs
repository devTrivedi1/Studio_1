using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 lookAtTarget;
    public bool playerClicked;
    Quaternion playerRot;
    public float moveSpeed = 50f;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    public Vector3 newPosition;
    public LayerMask layerMask;
    private Rigidbody rb;

    public PlayerLauncher playerLauncher;
    public PlayerLunge playerLunge;

    public AudioSource quickMove;
    public AudioClip quickMoveClip;

    public AudioSource chargedMove;
    public AudioClip chargedMoveClip;


    //Transform forceTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerLauncher = GetComponent<PlayerLauncher>();
        playerLunge = GetComponent<PlayerLunge>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            playerClicked = true;
            SetTargetPosition();
        }
        //Debug.Log(targetPosition);
    }


    private void FixedUpdate()
    {
        if (playerClicked)
        {
            Move();
            PlayDashingSounds();
            playerClicked = false;
        }

    }
    public void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            targetPosition = hit.point;
            //Debug.Log("target pos is " + targetPosition);
            //this.transform.LookAt(targetPosition);
            lookAtTarget = (targetPosition - transform.position) * Time.fixedDeltaTime;
            playerRot = Quaternion.LookRotation(lookAtTarget);

        }

    }


	public void Move()
	{

		if (playerLunge.isGrounded == false)
		{
			Vector3 direction = targetPosition - this.transform.position;
			rb.velocity = direction.normalized * moveSpeed;
		}
		else
		{
			Vector3 direction = new Vector3(targetPosition.x - rb.position.x, 0, targetPosition.z - rb.position.z);

			if (direction.magnitude > .05)
			{
				rb.velocity = direction.normalized * moveSpeed;
			}
		}

	}
    public void PlayDashingSounds()
    {
        if (moveSpeed <= 100)
        {
            quickMove.PlayOneShot(quickMoveClip);
        }
        if (moveSpeed > 100)
        {
            chargedMove.PlayOneShot(chargedMoveClip);
        }

    }
}
