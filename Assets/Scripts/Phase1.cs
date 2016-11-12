using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase1 : MonoBehaviour {

    public float upperLimit;
	public float lowerLimit;
	private float timer = 0.0f;
	private float surfaceWaitTime = 25.0f;
	private float phase1WaitTime = 15.0f;
	public float changeSpeed;
    public GameObject BathySphere;
	public Color highestSurface;
	public Color phase1Color;
	public bool upperLimitReached;
	public bool startDescent;
	List<TextElement> dialogue;
	private string test1 = "Tree is an awesome dude!";
	private string test2 = "The princess has exited the castle! You have to go find her";
	private string test3 = "The Vader is in the water for you !!!";
	private string test4 = "Maybe you should consider the razor";


    // Use this for initialization
    public void Start () {
		RenderSettings.fogColor = phase1Color;

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

		timer += Time.deltaTime;
		if (!upperLimitReached) {
			Color currentColor = Color.Lerp (RenderSettings.fogColor, highestSurface, changeSpeed);
			RenderSettings.fogColor = currentColor;


			if (timer > surfaceWaitTime) {
				StartCoroutine (WaitForOneSecond ());
				timer = 0.0f;
				upperLimitReached = true;
			}
		}
		if (startDescent) {
			Color currentColor = Color.Lerp (RenderSettings.fogColor,phase1Color,changeSpeed * 1.5f);
			RenderSettings.fogColor = currentColor;

			if (timer > phase1WaitTime) {
				EventManager.CallPhaseChanger ();
				startDescent = false;
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
