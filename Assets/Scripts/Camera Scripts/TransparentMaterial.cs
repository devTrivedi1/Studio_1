using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentMaterial : MonoBehaviour
{
	[SerializeField] List<ObjectInTheWay> currentlyBlocking;
	[SerializeField] List<ObjectInTheWay> alreadyTransparent;
	[SerializeField] private Transform player;
	private Transform camera;
	private PlayerDash dashed;
    public LayerMask mask1;
    public LayerMask mask2;

	// Start is called before the first frame update
	void Start()
	{
		currentlyBlocking = new List<ObjectInTheWay>();
		alreadyTransparent = new List<ObjectInTheWay>();
		camera = this.gameObject.transform;
	}

	// Update is called once per frame
	void Update()
	{
		GetAllObjects();
		MakeObjectSolid();
		MakeObjectTransparent();

	}
	void GetAllObjects()
	{
		currentlyBlocking.Clear();

		float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);
		Ray ray1Forward = new Ray(camera.position, player.position - camera.position); //Ray1 allows for multiple rays if needed
		Ray ray1Backwards = new Ray(player.position, camera.position - player.position); //Backward ray to make sure the object is transparent even if it's inside it

		RaycastHit[] hitForward = Physics.RaycastAll(ray1Forward, cameraPlayerDistance);
		RaycastHit[] hitBackward = Physics.RaycastAll(ray1Backwards, cameraPlayerDistance);

		foreach (var hit in hitForward)
		{
			if (hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
			{
				if (!currentlyBlocking.Contains(inTheWay))
				{
					currentlyBlocking.Add(inTheWay);
				}
			}
		}
		foreach (var hit in hitBackward)
		{
			if (hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
			{
				if (!currentlyBlocking.Contains(inTheWay))
				{
					currentlyBlocking.Add(inTheWay);
				}
			}
		}
	}
	void MakeObjectTransparent()
	{
		for (int i = 0; i < currentlyBlocking.Count; i++)
		{
			ObjectInTheWay inTheWay = currentlyBlocking[i];

			if (!alreadyTransparent.Contains(inTheWay))
			{
				inTheWay.ShowTransparent();
				alreadyTransparent.Add(inTheWay);
			}
		}
	}
	void MakeObjectSolid()
	{
		for (int i = alreadyTransparent.Count - 1; i >= 0; i--)
		{
			ObjectInTheWay wasInTheWay = alreadyTransparent[i];
			if (!currentlyBlocking.Contains(wasInTheWay))
			{
				wasInTheWay.ShowSolid();
				alreadyTransparent.Remove(wasInTheWay);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (dashed.isDashing)
		{
			MakeObjectTransparent();
            Physics.IgnoreLayerCollision(mask1, mask2, true);
		}
	}
    void OnTriggerExit(Collider other)
    {
        if(dashed.hasDashed)
        {
            MakeObjectSolid();
            Physics.IgnoreLayerCollision(mask1, mask2, false);
        }
    }
}
