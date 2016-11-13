using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Phase5: MonoBehaviour {

    public GameObject BathySphere;
	public GameObject UltraGhoul;
	public SpriteRenderer sprite;
	public Color targetColor;
	public Color targetColor2;
	bool hallucinate = false;
	bool fadeToBlack = true;// No one but me can save myself, but it's too late
	float timer;
	float descentTime = 8f;
	public float colorChangeSpeed;
	int state = 0;
	bool heavyShake = true;


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
				EventManager.CallRockMovement (1);
				hallucinate = true;
				state++;
			}
			break;

		case 2:
			//Read the player input
			if (hallucinate) {
				StartCoroutine (Hallucinations ());
				hallucinate = false;
			}
			break;

		case 3:

			if (UltraGhoul.transform.position.z > 18.0f) {
				FadeInTheMonster();

			} else {
				UltraGhoul.GetComponent<MoveGhoul> ().enabled = false;
				UltraGhoul.GetComponent<Animator> ().enabled =false;

				if (heavyShake) {
					StartCoroutine (AnotherHeavyShake ());
					heavyShake = false;
					timer = 0.0f;
				}

			}

			break;


		case 4:
			//Raise the player
			timer += Time.deltaTime;
			Color currentColor2 = Color.Lerp (RenderSettings.fogColor, targetColor2, colorChangeSpeed);
			RenderSettings.fogColor = currentColor2;
			if (timer > descentTime) {
				state++;
			}

			break;


		case 5:
			//Fade to black
			if (fadeToBlack) {
				StartCoroutine (FadeToBlack());
				fadeToBlack = false;
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


	IEnumerator  AnotherHeavyShake(){

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
		state++;
		timer = 0.0f;
	}


	IEnumerator Quiet(){

		AudioManager.instance.PlayMusic(AudioManager.instance.generalEnvironment[1],true);
		yield return new WaitForSeconds (4.0f);
		state++;

	}

	void FadeInTheMonster(){
		UltraGhoul.GetComponent<MoveGhoul>().enabled = true;
		UltraGhoul.GetComponent<Animator>().enabled = true;
	}

	IEnumerator FadeToBlack(){

		float interpolator = 0.01f;

		while(interpolator < 1.0f){
			sprite.color = new Color(sprite.color.r,sprite.color.g, sprite.color.b,Mathf.Lerp (sprite.color.a, 1.0f, interpolator));
			yield return null;
		}
		interpolator = 1.0f;

		//Game Ends
	}
}
