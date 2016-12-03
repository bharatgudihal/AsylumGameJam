using UnityEngine;
using System.Collections;

public class rotationIndicator : MonoBehaviour 
{

	public float speed = 1.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(speed * Vector3.back * Time.deltaTime);


		if (transform.localRotation.z < -0.5f || transform.localRotation.z > 0.5f) 
		{
			speed = -speed;
		}

//		Debug.Log (transform.localRotation);
	}
       
}
