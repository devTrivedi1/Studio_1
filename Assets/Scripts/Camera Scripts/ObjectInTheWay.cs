
using UnityEngine;

public class ObjectInTheWay : MonoBehaviour
{
	[SerializeField] private GameObject solidBody;
	[SerializeField] private GameObject transparentBody;

	// Start is called before the first frame update
	void Start()
	{
       
	}

	public void ShowTransparent()
    {
        solidBody.SetActive(false);
        transparentBody.SetActive(true);
    }
    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transparentBody.SetActive(false);
    }
}
