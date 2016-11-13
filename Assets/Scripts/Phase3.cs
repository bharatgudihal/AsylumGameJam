using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase3: MonoBehaviour {

    public GameObject BathySphere;

	public GameObject lever_Object;
	clickButton button;


	List<TextElement> dialogue;
	public Color targetColor;
	float timer;
	float descentTime = 5f;
	public float colorChangeSpeed;
	int state = 0;


    // Use this for initialization
    public void Start () {
		dialogue = new List<TextElement> ();
		button = lever_Object.gameObject.GetComponent<clickButton>();
	}

	public void EnablePhase(){
		dialogue.Add (new TextElement("Shit",0.1f,4f));
		dialogue.Add (new TextElement("Lost sight of you",0.1f,4f));
		dialogue.Add (new TextElement("Hold on",0.1f,4f));
		dialogue.Add (new TextElement("Looks like you've got an oxygen leak.",0.1f,4f));
		dialogue.Add (new TextElement("Switch to your back up tank",0.1f,2f));
		dialogue.Add (new TextElement("I'll focus on getting you out",0.1f,4f));
		EventManager.CallTextWriter (dialogue);
		state = 1;
		AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [3], true);
	}

	public void DisablePhase(){
		state = 0;
	}


	// Update is called once per frame
	public void Update () 
	{		
		switch (state) 
		{
		case 1:
			timer += Time.deltaTime;
			Color currentColor = Color.Lerp (RenderSettings.fogColor, targetColor, colorChangeSpeed);
			RenderSettings.fogColor = currentColor;

			if (timer > descentTime)
			{
				timer = 0f;
				state++;
			}
			break;

		case 2:
			//Read the player input
			if (button.isTrigger == true) 
			{
				StartCoroutine (stateTwo());
				button.isTrigger = false;
			}
			break;

		case 3:
			//StartCoroutine (LightShake ());
			//state = 4;
			break;
		}
	}

	IEnumerator stateTwo()
	{
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (LightShake());
	}


	IEnumerator  LightShake(){
		
		//Reached the top
		AudioManager.instance.PlayOneShotSFX(AudioManager.instance.generalSFX[4]);
		//AudioManager.instance.PlayOneShotSFX (phase1SfxClips [0]);
		EventManager.CameraShaker (0.03f, 0.0005f);

		yield return new WaitForSeconds (2.0f);

		dialogue.Add (new TextElement("That will buy you some time", 0.1f, 4f));

		EventManager.CallTextWriter (dialogue);
		EventManager.CallLevelChanger ();
		yield return new WaitForSeconds (6.0f);
		StartCoroutine (TransitionToPhase4() );
	}

	IEnumerator TransitionToPhase4()
	{
		yield return new WaitForSeconds (5.0f);
		EventManager.CallPhaseChanger ();

	}


}
