using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lever : MonoBehaviour
{
    //angle 
    public int MAX_Angle = 45;
    public int MIN_Angle = -45;
    bool isLocking = false;
	bool isMaxReached = false;
	public bool isTrigger = false;
	private AudioSource source;
	public AudioClip sound;
    Vector3 initPosition;
	bool isClicked;

	List<TextElement> dialogue;

    // Use this for initialization
    void Start ()
    {
		source = GetComponent<AudioSource> ();	
	}

    // Update is called once per frame
    void Update()
    {

        //click the lever
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && Input.GetMouseButtonDown(0) && hit.collider.name == this.gameObject.name)
            {
				isClicked = true;
                if(isLocking == false)
                {
                    initPosition = Input.mousePosition;
                }

                isLocking = true;
            }
        }

        //If release the mouse, reset the angle
		if (Input.GetMouseButtonUp(0) && isClicked)
        {
            isLocking = false;
			isClicked = false;
            Quaternion quate = Quaternion.identity;
            quate.eulerAngles = new Vector3(45, 0, 0);
			source.PlayOneShot (sound);
            this.transform.localRotation = quate;
        }


        //If the lever is locking, we can move it!!!
        if(isLocking == true)
        {
            Quaternion quate = Quaternion.identity;
            quate.eulerAngles = new Vector3(initPosition.y - Input.mousePosition.y, 0, 0);

            //Debug.Log(initPosition.y - Input.mousePosition.y);
			if (initPosition.y - Input.mousePosition.y > MIN_Angle && initPosition.y - Input.mousePosition.y < MAX_Angle) {
				this.transform.localRotation = quate;
			} else {									
				EventManager.CallEventTrigger ();
			}
				
			if (this.transform.rotation.eulerAngles.x > 80) 
			{
				isTrigger = true;

			}

        }

    }
}
