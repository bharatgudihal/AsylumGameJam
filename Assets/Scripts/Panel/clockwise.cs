using UnityEngine;
using System.Collections;

public class clockwise : MonoBehaviour 
{

	public float speed = 1.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(speed * Vector3.forward * Time.deltaTime);
	}
}
