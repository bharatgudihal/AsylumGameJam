using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase5: MonoBehaviour {

    public GameObject BathySphere;
	public Color targetColor;
	public Color targetColor2;
	float timer;
	float descentTime = 5f;
	public float colorChangeSpeed;
	int state = 0;


    // Use this for initialization
    public void Start () {

	}

	public void EnablePhase(){
		state = 1;
	}

	public void DisablePhase(){
		state = 0;
	}

	
	// Update is called once per frame
	public void Update () {		
		switch (state) {
		case 1:
			timer += Time.deltaTime;
			Color currentColor = Color.Lerp (RenderSettings.fogColor, targetColor, colorChangeSpeed);
			RenderSettings.fogColor = currentColor;
			if (timer > descentTime) {
				timer = 0f;
				state++;
			}
			break;

		case 2:
			//Read the player input
			Hallucinations();
			break;

		case 3:
			StartCoroutine (HeavyShake ());
			break;

		case 4:
			timer += Time.deltaTime;
			Color currentColor2 = Color.Lerp (RenderSettings.fogColor, targetColor2, colorChangeSpeed);
			RenderSettings.fogColor = currentColor2;
			if (timer > descentTime) {
				timer = 0f;
				state++;
			}
			break;

		}
	}

	IEnumerator  Hallucinations(){
		//Play Hallucination sounds
		yield return new WaitForSeconds (3.0f);
		StartCoroutine (HeavyShake ());
	}



	IEnumerator  HeavyShake(){

		//Reached the top
		AudioManager.instance.StopMusic();
		//AudioManager.instance.PlayOneShotSFX (phase1SfxClips [0]);

		//Shake
		AudioManager.instance.PlayMusic(AudioManager.instance.generalSFX[2],true);
		EventManager.CameraShaker (0.04f, 0.0005f);
		yield return new WaitForSeconds (2.0f);
		EventManager.CameraShaker (0.05f, 0.0005f);
		yield return new WaitForSeconds (6.0f);
		AudioManager.instance.StopMusic();
		StartCoroutine (Quiet ());
	}

	IEnumerator Quiet(){

		AudioManager.instance.PlayMusic(AudioManager.instance.generalEnvironment[1],true);
		yield return new WaitForSeconds (4.0f);
	}

	//IEnumerator FadeInTheMonster(){



	//}


}
