using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{

    public float speed = 1.0f;

    bool isLocking = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        //click the lever
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && Input.GetMouseButtonDown(0) && hit.collider.name == this.gameObject.name)
            {
                isLocking = true;
            }
        }

        //If release the mouse, reset the angle
        if (Input.GetMouseButtonUp(0))
        {
            isLocking = false;
        }


        if(isLocking == true)
        {
            transform.Rotate(speed * Vector3.up * Time.deltaTime);
        }

    }
}
