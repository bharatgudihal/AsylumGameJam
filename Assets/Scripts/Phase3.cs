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
	public List<SteamEffect> steamEffects;
	public BubblesEffect bubbles;
	public AudioSource backgroundMusic;

    // Use this for initialization
    public void Start () {
		dialogue = new List<TextElement> ();
		button = lever_Object.gameObject.GetComponent<clickButton>();
	}

	public void EnablePhase(){
		state = 1;
		AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [2], true);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [3], true);
		bubbles.Disable ();
		backgroundMusic.clip = AudioManager.instance.generalEnvironment[10];
		backgroundMusic.loop = true;
		backgroundMusic.Play ();
		StartCoroutine (DialogManager ());
	}

	public void DisablePhase(){
		state = 0;
		backgroundMusic.Stop ();
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
			}
			break;

		case 2:
			//Read the player input
			//if (button.isTrigger == true) 
			//{
			StartCoroutine (LightShake ());
			state++;
				//button.isTrigger = false;
			//}
			break;

		case 3:
			//StartCoroutine (LightShake ());
			//state = 4;
			break;
		}
	}

	//IEnumerator stateTwo()
	//{
		//yield return new WaitForSeconds (10.0f);
		//StartCoroutine (LightShake());
	//}


	IEnumerator  LightShake(){
		//yield return new WaitForSeconds (30.0f);
		//Reached the top
		AudioManager.instance.PlayOneShotSFX(AudioManager.instance.generalSFX[4]);
		//AudioManager.instance.PlayOneShotSFX (phase1SfxClips [0]);
		EventManager.CameraShaker (0.03f, 0.0005f);
		foreach (SteamEffect effect in steamEffects) {
			effect.Enable ();
		}

		dialogue.Add (new TextElement("That will buy you some time", 0.08f, 4f));

		EventManager.CallTextWriter (dialogue);
		EventManager.CallLevelChanger ();
		yield return new WaitForSeconds (3.0f);
		foreach (SteamEffect effect in steamEffects) {
			effect.Disable ();
		}
		StartCoroutine (TransitionToPhase4() );
	}

	IEnumerator TransitionToPhase4()
	{
		yield return new WaitForSeconds (5.0f);
		EventManager.CallPhaseChanger ();

	}

	IEnumerator DialogManager(){		
		dialogue.Add (new TextElement("Shit",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		dialogue.Clear ();

        EventManager.BathySphereSpiner(40, 999);

		dialogue.Add (new TextElement("Lost sight of you",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (4f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("Hold on",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (3f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("Looks like you've got an oxygen leak.",0.08f,1f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (6f);
		dialogue.Clear ();
		dialogue.Add (new TextElement("I'll focus on getting you out while you fix it",0.08f,4f));
		EventManager.CallTextWriter (dialogue);
		yield return new WaitForSeconds (10f);
		EventManager.triggerEvent += triggerEvent;
	}

	void triggerEvent(){
		EventManager.triggerEvent -= triggerEvent;
		state++;
	}
}
