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

    public AudioSource floorSpikes;
    public AudioClip floorSpikesClip;

    // Start is called before the first frame update
    void Start()
    {
        startPos = theSpikes.transform.position;
        endPos = riseHeight;
        /*lerpTimeUp = 1;
        lerpTimeDown = 3;*/
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpikesUp();
        MoveSpikesDown();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "GuardChaser")
        {
            touchedThePlate = true;
            hasTouchedPlate = true;

            floorSpikes.PlayOneShot(floorSpikesClip);
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
            float ratio = lerpTimeUp / currentLerpTimeUp;
            theSpikes.transform.position = Vector3.Lerp(startPos, startPos + endPos, ratio);
        }

       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            touchedThePlate = false;
            currentLerpTimeUp = 0;
            currentLerpTimeDown = 0;
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
               /* trapPanel = this.gameObject;
                trapPanel.SetActive(false);*/
            }
        }
       
    }
}
