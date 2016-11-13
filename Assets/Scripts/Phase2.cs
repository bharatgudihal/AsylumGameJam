using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase2 : MonoBehaviour {

    public GameObject BathySphere;
	List<TextElement> dialogue;
	public Color targetColor;
	float timer;
	float descentTime = 10f;
	public float colorChangeSpeed;
	public float positionChangeSpeed;
	public float finalPosition;
	int state = 0;
	public AudioSource backgroundMusic;

    // Use this for initialization
    public void Start () {
		dialogue = new List<TextElement> ();
		//EventManager.CallTextWriter (dialogue);

	}

	public void EnablePhase(){
		state = 1;
	}

	public void DisablePhase(){
		state = 0;
		AudioManager.instance.StopMusic (AudioManager.instance.generalSFX [3]);
		backgroundMusic.Stop ();
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
				BathySphere.GetComponent<Animator> ().enabled = true;
				EventManager.CallLevelChanger ();
				StartCoroutine (TransitionToPhase3 ());
			}
			break;
		default:
			break;
		}
	}

	IEnumerator TransitionToPhase3(){
		yield return new WaitForSeconds (5.0f);
		EventManager.CallPhaseChanger ();


	}


}
