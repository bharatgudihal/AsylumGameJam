using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	bool active;

	void Awake(){
		EventManager.floorMover += Activate;
	}

	void Activate(){
		active = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			float currentY = Mathf.Lerp (transform.position.y, 0f, 0.02f);
			transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
			if (currentY >= -17) {
				active = false;
				EventManager.CallRockMovement(1);
				EventManager.CallLandingEffect ();
			}
		}	
	}
}
