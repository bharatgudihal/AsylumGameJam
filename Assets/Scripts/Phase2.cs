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
				StartCoroutine (TransitionToPhase3 ());
			}
			break;
//		case 2:
//			float currentPosition = Mathf.Lerp (BathySphere.transform.position.y, finalPosition, positionChangeSpeed);
//			BathySphere.transform.position = new Vector3 (BathySphere.transform.position.x, currentPosition, BathySphere.transform.position.z);
//			if (currentPosition <= finalPosition + 0.1) {
//				state++;
//			}
//			break;
		default:
			break;
		}
	}

	IEnumerator TransitionToPhase3(){
		yield return new WaitForSeconds (5.0f);
		EventManager.CallPhaseChanger ();

	}


}
