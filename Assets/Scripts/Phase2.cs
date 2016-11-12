using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase2 : MonoBehaviour {

    public float upperLimit;
	public float lowerLimit;
    public GameObject BathySphere;
	public float climbSpeed;
	public float descendSpeed;
	public bool upperLimitReached;
	public bool startDescent;
	List<TextElement> dialogue;


    // Use this for initialization
    public void Start () {
		dialogue = new List<TextElement> ();

		EventManager.CallTextWriter (dialogue);
	}
	
	// Update is called once per frame
	public void Update () {		
		if (!upperLimitReached) {
			float initPos = BathySphere.transform.position.y;
			float finalPos = Mathf.Lerp (initPos, upperLimit, climbSpeed);
			BathySphere.transform.position = new Vector3(BathySphere.transform.position.x,finalPos,BathySphere.transform.position.z);
			if (finalPos >= upperLimit-1) {
				upperLimitReached = true;
				StartCoroutine (WaitForOneSecond ());
			}
		}
		if (startDescent) {
			float initPos = BathySphere.transform.position.y;
			float finalPos = Mathf.Lerp (initPos, lowerLimit, descendSpeed);
			BathySphere.transform.position = new Vector3(BathySphere.transform.position.x,finalPos,BathySphere.transform.position.z);
			if (finalPos <= lowerLimit+1) {
				startDescent = false;
				EventManager.CallPhaseChanger ();
			}
		}
	}

	IEnumerator  WaitForOneSecond(){
		yield return new WaitForSeconds (1.0f);
		EventManager.CameraShaker (0.03f, 0.0005f);
		startDescent = true;
		yield return new WaitForSeconds (1.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);
	}
}
