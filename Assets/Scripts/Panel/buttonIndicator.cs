using UnityEngine;
using System.Collections;

public class buttonIndicator : MonoBehaviour 
{
	float initPosition_x = 0.0f;
	float initPosition_y = 0.0f;
	float initPosition_z = 0.0f;

	// Use this for initialization
	void Start () 
	{
		initPosition_x = transform.localPosition.x;
		initPosition_y = transform.localPosition.y;
		initPosition_z = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.GetComponent<clickButton> ().isTrigger == true) 
		{
			transform.localPosition = new Vector3 (initPosition_x - 0.0005f, initPosition_y, initPosition_z - 0.0005f);
		} 
		else 
		{
			transform.localPosition = new Vector3 (initPosition_x, initPosition_y, initPosition_z);
		}
	}
}
