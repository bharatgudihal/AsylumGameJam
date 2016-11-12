using UnityEngine;
using System.Collections;

public class backgroundMoving : MonoBehaviour
{
    public float initPosition_Y = 0.0f;
    public float MAX_Position_Y = 0.0f;
    public float velocity = 1.0f;

	public bool trigger = false;

	void Awake()
	{
		EventManager.RockMovement += functionTrigger;
	}

	// Use this for initialization
	void Start ()
    {
		transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

	// Update is called once per frame
	void Update ()
    {

		if (trigger == true) 
		{
			transform.Translate(velocity * Vector3.up * Time.deltaTime);

			if(transform.localPosition.y >= MAX_Position_Y)
			{
				transform.localPosition = new Vector3(gameObject.transform.localPosition.x, initPosition_Y, gameObject.transform.localPosition.z);
			}
		}
    }

	public void functionTrigger()
	{
		trigger = true;
	}


}
