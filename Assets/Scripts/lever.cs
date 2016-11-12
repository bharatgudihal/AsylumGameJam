using UnityEngine;
using System.Collections;

public class lever : MonoBehaviour
{
    //angle 
    public int MAX_Angle = 45;
    public int MIN_Angle = -45;

    bool isLocking = false;

    Vector3 initPosition;

    // Use this for initialization
    void Start ()
    {
	
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

                if(isLocking == false)
                {
                    initPosition = Input.mousePosition;
                }

                isLocking = true;
            }
        }

        //If release the mouse, reset the angle
        if (Input.GetMouseButtonUp(0))
        {
            isLocking = false;

            Quaternion quate = Quaternion.identity;
            quate.eulerAngles = new Vector3(45, 0, 0);

            this.transform.localRotation = quate;

        }


        //If the lever is locking, we can move it!!!
        if(isLocking == true)
        {

            Quaternion quate = Quaternion.identity;
            quate.eulerAngles = new Vector3(initPosition.y - Input.mousePosition.y, 0, 0);

            //Debug.Log(initPosition.y - Input.mousePosition.y);

            if (initPosition.y - Input.mousePosition.y > MIN_Angle && initPosition.y - Input.mousePosition.y < MAX_Angle)
            {
                this.transform.localRotation = quate;
            }
            
        }

    }
}
