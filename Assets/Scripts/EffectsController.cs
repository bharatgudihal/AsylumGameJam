using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectsController : MonoBehaviour {

	public List<SparkEffect> sparkEffects;
	bool isActive;

	void Awake(){
		EventManager.effectsStarter += activate;
	}

	// Use this for initialization
	void Start () {
	
	}

	void activate(){
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			StartCoroutine (PlayEffect());
		}
	}

	IEnumerator PlayEffect(){
		isActive = false;
		int index = Random.Range (0, sparkEffects.Count);
		sparkEffects [index].Burst ();
		yield return new WaitForSeconds (3f);
		isActive = true;
	}
}
