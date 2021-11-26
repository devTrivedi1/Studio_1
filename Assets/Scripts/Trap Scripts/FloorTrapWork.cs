using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrapWork : MonoBehaviour
{
    public GameObject theSpikes;

    private Vector3 startPos;
    private Vector3 endPos;

    public Vector3 riseHeight;
    public bool touchedThePlate;
    public bool hasTouchedPlate;

    public float lerpTimeUp;
    private float currentLerpTimeUp = 0;

    public float lerpTimeDown;
    private float currentLerpTimeDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = theSpikes.transform.position;
        endPos = riseHeight;
        lerpTimeUp = 1;
        lerpTimeDown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpikesUp();
        MoveSpikesDown();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            touchedThePlate = true;
            hasTouchedPlate = true;
        }
    }

    private void MoveSpikesUp()
    {
        if (touchedThePlate)
        {
            currentLerpTimeUp += Time.deltaTime;
            if (currentLerpTimeUp >= lerpTimeUp)
            {
                currentLerpTimeUp = lerpTimeUp;
            }
            float ratio = currentLerpTimeUp / lerpTimeUp;
            theSpikes.transform.position = Vector3.Lerp(startPos, startPos + endPos, ratio);
        }

       
    }
    private void OnCollisionExit(Collision collision)
{
       
        if (collision.gameObject.tag == "Player")
        {
            touchedThePlate = false;
        }
    }

    private void MoveSpikesDown()
    {
        if(touchedThePlate == false)
        {
            currentLerpTimeDown += Time.deltaTime;
            if (currentLerpTimeDown >= lerpTimeDown)
            {
                currentLerpTimeDown = lerpTimeDown;
            }
            float ratio = currentLerpTimeDown / lerpTimeDown;
            theSpikes.transform.position = Vector3.Lerp(startPos + endPos, startPos, ratio);
            if(theSpikes.transform.position == startPos && hasTouchedPlate)
            {
                GameObject trapPanel = GetComponent<GameObject>();
                trapPanel = this.gameObject;
                trapPanel.SetActive(false);
            }
        }
       
    }
}
