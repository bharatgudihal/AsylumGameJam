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
	public AudioClip slowDownClip;
	public AudioClip monsterClip;
	public AudioSource backgroundMusic;

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
				hallucinate = true;
				state++;
			}
			break;

		case 2:
			//Read the player input
			if (hallucinate) {
				AudioManager.instance.PlayMusic (AudioManager.instance.generalSFX [3], true);
				StartCoroutine (Hallucinations ());
				hallucinate = false;
			}
			break;

		case 3:

			if (UltraGhoul.transform.position.z > 60.0f) {
				FadeInTheMonster();

			} else {
				if (heavyShake) {
					heavyShake = false;
					state++;
				}
			}
			break;



		case 4:
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

		//AudioManager.instance.PlayOneShotSFX (phase1SfxClips [0]);

		//Shake
		EventManager.CameraShaker (0.04f, 0.0005f);
		yield return new WaitForSeconds (2.0f);
		EventManager.CameraShaker (0.05f, 0.0005f);
		yield return new WaitForSeconds (6.0f);
		EventManager.CallFloorMover ();
		StartCoroutine (Quiet ());
	}




	IEnumerator Quiet(){
		backgroundMusic.Stop ();
		AudioManager.instance.PlayMusic(slowDownClip,false);
		AudioManager.instance.PlayMusic (AudioManager.instance.generalSFX[2],false);
		EventManager.CameraShaker (0.1f, 0.0005f);
		//Trigger the audio to stop
		yield return new WaitForSeconds (5.0f);
		AudioManager.instance.StopMusic ();
		AudioManager.instance.PlayMusic(AudioManager.instance.generalEnvironment[1],true);
		backgroundMusic.clip = monsterClip;
		backgroundMusic.loop = false;
		backgroundMusic.Play ();
		yield return new WaitForSeconds (4.0f);
		state++;

	}

	void FadeInTheMonster(){
		UltraGhoul.GetComponent<MoveGhoul>().enabled = true;
		UltraGhoul.GetComponent<Animator>().enabled = true;
	}

	IEnumerator FadeToBlack(){

		float interpolator = 0.01f;

		while(sprite.color.a != 1.0f){
			sprite.color = new Color(sprite.color.r,sprite.color.g, sprite.color.b,Mathf.Lerp (sprite.color.a, 1.0f, interpolator));
			yield return null;
		}
		interpolator = 1.0f;
		UltraGhoul.SetActive(false);
		//Game Ends

	}
}
