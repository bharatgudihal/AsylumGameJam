using UnityEngine;
using System.Collections;

public class backgroundMoving : MonoBehaviour
{
    public float initPosition_Y = 0.0f;
    public float MAX_Position_Y = 0.0f;
    public float velocity = 1.0f;


	// Use this for initialization
	void Start ()
    {
        transform.localPosition = new Vector3(0, initPosition_Y, gameObject.transform.localPosition.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(velocity * Vector3.up * Time.deltaTime);

        if(transform.localPosition.y >= MAX_Position_Y)
        {
            transform.localPosition = new Vector3(0, initPosition_Y, gameObject.transform.localPosition.z);
        }

    }
}
