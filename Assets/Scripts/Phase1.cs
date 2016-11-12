using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase1 : MonoBehaviour {

    public float upperLimit;
	public float lowerLimit;
    public GameObject BathySphere;
	public float climbSpeed;
	public float descendSpeed;
	public bool upperLimitReached;
	public bool startDescent;
	List<TextElement> dialogue;
	private string test1 = "Tree is an awesome dude!";
	private string test2 = "The princess has exited the castle! You have to go find her";
	private string test3 = "The Vader is in the water for you !!!";
	private string test4 = "Maybe you should consider the razor";

    // Use this for initialization
    public void Start () {
		dialogue = new List<TextElement> ();

		TextElement element1 = new TextElement(test1,0.1f);
		TextElement element2 = new TextElement(test2,0.1f);
		TextElement element3 = new TextElement(test3,0.1f);
		TextElement element4 = new TextElement(test4,0.1f);

		dialogue.Add (element1);
		dialogue.Add (element2);
		dialogue.Add (element3);
		dialogue.Add (element4);
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
