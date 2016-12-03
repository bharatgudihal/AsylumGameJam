using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase1 : MonoBehaviour {

    public float upperLimit;
	public float lowerLimit;
	private float timer = 0.0f;
	private float surfaceWaitTime = 20.0f;
	private float phase1WaitTime = 60.0f;
	public float changeSpeed;
	public Color highestSurface;
	public Color phase1Color;
	public bool upperLimitReached;
	public bool startDescent;
	List<TextElement> dialogue;
	bool isPhaseActive = true;
	//the audio clips for this phase
	public AudioClip[] phase1AudioClips;
	public AudioClip[] phase1SfxClips;
	bool stopcoroutines;
	public AudioSource backgroundMusic;

	public GameObject Lever;
	clickButton button;
	bool interactionStep = false;

	public void Awake(){
	}

    // Use this for initialization
    public void Start () {
		
		AudioManager.instance.PlayMusic (phase1AudioClips[0],true);
		AudioManager.instance.PlayMusic (phase1AudioClips[1],true);

		RenderSettings.fogColor = phase1Color;
		button = Lever.gameObject.GetComponent<clickButton> ();

		dialogue = new List<TextElement> ();
		StartCoroutine (DialogManager ());
		backgroundMusic.clip = AudioManager.instance.generalEnvironment [7];
		backgroundMusic.loop = true;
		backgroundMusic.Play ();
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if (isPhaseActive) 
		{
			timer += Time.deltaTime;
			if (!upperLimitReached) 
			{
				Color currentColor = Color.Lerp (RenderSettings.fogColor, highestSurface, changeSpeed);
				RenderSettings.fogColor = currentColor;
				//EventManager.CallRockMovement (0);
				if (timer > surfaceWaitTime && !stopcoroutines) 
				{					
					StartCoroutine (WaitForOneSecond ());
					timer = 0.0f;
					upperLimitReached = true;
				}
			}
			if (startDescent) 
			{			
                
				Color currentColor = Color.Lerp (RenderSettings.fogColor, phase1Color, changeSpeed);
				RenderSettings.fogColor = currentColor;

				if (timer > phase1WaitTime) 
				{
					startDescent = false;
				}
			}

			if (interactionStep == true) 
			{
				//if (button.isTrigger == true) 
				//{
					StartCoroutine (interaction());					
				interactionStep = false;
				//button.isTrigger = false;
				//}

			}

		}
	}


	IEnumerator interaction()
	{
		yield return new WaitForSeconds (1f);	
		EventManager.CalldisplayStrings ("That should put you back on course", 0.08f, 0.5f);
		EventManager.CallPhaseChanger ();
		startDescent = false;
	}


	IEnumerator  WaitForOneSecond(){
		stopcoroutines = true;
		//Reached the top
		AudioManager.instance.StopMusic();
		AudioManager.instance.PlayMusic(phase1SfxClips [0],false);



		//Trigger the audio to stop
		yield return new WaitForSeconds (2.0f);
		EventManager.CameraShaker (0.03f, 0.0005f);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalSFX[2],false);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalSFX[3],true);
		yield return new WaitForSeconds (3.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);
		EventManager.CallRockMovement (1);
		backgroundMusic.Stop ();
		timer = 0.0f;
		yield return new WaitForSeconds (5.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);
		EventManager.CallRockMovement (3);
		backgroundMusic.clip = AudioManager.instance.generalEnvironment[8];
		backgroundMusic.loop = true;
		backgroundMusic.Play ();


		yield return new WaitForSeconds (3.0f);

        EventManager.BathySphereSpiner(5, 10);

		EventManager.CameraShaker (0.03f, 0.00009f);
		yield return new WaitForSeconds (3.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);
		yield return new WaitForSeconds (3.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);
		yield return new WaitForSeconds (3.0f);
		EventManager.CameraShaker (0.03f, 0.00009f);

		startDescent = true;
		AudioManager.instance.StopMusic();
		AudioManager.instance.PlayMusic (AudioManager.instance.generalSFX[3],true);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [0],true);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [1],true);
	}

	public void DisablePhase(){
		isPhaseActive = false;
	}

	public void triggerEvent(){
		EventManager.triggerEvent -= triggerEvent;
		interactionStep = true;
	}

	IEnumerator DialogManager(){
		dialogue.Add (new TextElement("Glad to have you back!",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("Hang tight",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("I'll have you on land in no time",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (7f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("What's going on?",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (10f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("Why are you descending?",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (5f);
		dialogue.Clear();
		dialogue.Add (new TextElement("It's alright",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (3f);
		dialogue.Clear();
		dialogue.Add (new TextElement("We can fix this",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		dialogue.Clear();
		dialogue.Add (new TextElement("Activate the crane override",0.08f,3f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		EventManager.triggerEvent += triggerEvent;
		yield return 0;
	}
}
