using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase4 : MonoBehaviour 
{

	public GameObject button_Object_L;
	public GameObject button_Object_R;

	clickButton button_L;
	clickButton button_R;

	List<TextElement> dialogue;
	public int step = 5;

	public float duration = 1.0F;
	public GameObject lightObject;
	Light cabinLight;
	public List<SmallWaterLeakEffect> waterLeakEffects;
	public AudioSource backgroundMusic;

	// Use this for initialization
	public void Start () 
	{
		cabinLight = lightObject.GetComponent<Light> (); 
		dialogue = new List<TextElement> ();

		button_L = button_Object_L.gameObject.GetComponent<clickButton> ();
		button_R = button_Object_R.gameObject.GetComponent<clickButton> ();

//		switch_D = switch_Object_D.gameObject.GetComponent<clickButton> ();
	}

	public void EnablePhase()
	{
		dialogue.Add (new TextElement("", 0.1f, 2.0f));
		dialogue.Add (new TextElement("I have a solution", 0.1f, 4.0f));
		dialogue.Add (new TextElement("Press one of the buttons", 0.1f, 4.0f));
		StartCoroutine (timeDelay(14.0f));
		EventManager.CallTextWriter (dialogue);
		backgroundMusic.clip = AudioManager.instance.generalEnvironment [11];
		backgroundMusic.loop = true;
		backgroundMusic.Play ();
	}

	public void DisablePhase(){
		step = 0;
	}


	// Update is called once per frame
	public void Update () 
	{
		if (step == 7) 
		{
			if (button_L.isTrigger == true || button_R.isTrigger == true) 
			{
				button_L.isTrigger = false;
				button_R.isTrigger = false;

				StartCoroutine (Shinning (1.0f));
				StartCoroutine (callText ("Again", 0.1f, 8));
				AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [4], true);
				AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [5], true);
				AudioManager.instance.PlayMusic (AudioManager.instance.generalEnvironment [6], true);
			}
		}
		if (step == 8) 
		{
			if (button_L.isTrigger == true || button_R.isTrigger == true) 
			{
				button_L.isTrigger = false;
				button_R.isTrigger = false;

				StartCoroutine (Shinning (1.0f));
				StartCoroutine (callText ("Again", 0.1f, 9));
			}
		}

		if (step == 9) 
		{
			if (button_L.isTrigger == true || button_R.isTrigger == true) 
			{
				button_L.isTrigger = false;
				button_R.isTrigger = false;

				StartCoroutine (callText ("Good", 0.1f, 10));
				cabinLight.intensity = 0;
				StartCoroutine (StartLeaking ());
				StartCoroutine (TurnOffLights ());
				EventManager.CallEffectsStarter ();
				EventManager.CallPhaseChanger ();
			}
		}

	}

	IEnumerator TurnOffLights(){
		yield return new WaitForSecondsRealtime(10f);
		cabinLight.intensity = 0;
	}
		
	IEnumerator Shinning(float time)
	{
		yield return new WaitForSecondsRealtime(0.1f);

		for (float i = 0; i <= time; i += Time.deltaTime) 
		{
			float phi = Time.time / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos(phi) * 0.5F + 1.0F;
			cabinLight.intensity = amplitude;
			yield return 0;

		}


	}
		
	IEnumerator callText(string text, float delay, int i_step)
	{
		yield return new WaitForSeconds(0.1f);
		EventManager.CalldisplayStrings (text, 0.1f, 1.0f);
		yield return new WaitForSeconds(1.0f);
		button_L.isTrigger = false;
		step = i_step;
	}

	IEnumerator timeDelay(float time)
	{
		yield return new WaitForSeconds(time);
		step = 7;
	}

	IEnumerator StartLeaking(){
		foreach (SmallWaterLeakEffect effect in waterLeakEffects) {
			effect.Enable ();
		}
		yield return null;
	}
}
