using UnityEngine;
using System.Collections;

public class indicator : MonoBehaviour 
{

	public float speed = 0.001f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.localPosition = new Vector3 (gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + speed, gameObject.transform.localPosition.z);
//		transform.Translate (speed * Vector3.up * Time.deltaTime);


		if (this.transform.localPosition.y < -0.25f || this.transform.localPosition.y > -0.2f) 
		{
			speed = -speed;
		}

//		this.transform.localPosition = 
	}
}
