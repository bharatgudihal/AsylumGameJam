﻿using UnityEngine;
using System.Collections;

public class CustomGameManager : MonoBehaviour {
    int phase = 0;
	Phase1 phase1;
	Phase2 phase2;
	Phase3 phase3;

	void Awake(){
		EventManager.phaseChanger += ChangePhase;
	}

	// Use this for initialization
	void Start () {
        phase = 0;
		phase1 = this.gameObject.GetComponent<Phase1>();
		phase2 = this.gameObject.GetComponent<Phase2>();
		phase3 = this.gameObject.GetComponent<Phase3>();
    }
	
	// Update is called once per frame
	void Update () {
		if (phase == 0) {			
			phase1.Update ();
		} else if (phase == 1) {
			phase2.Update ();
		} else if(phase == 2){
			phase3.Update ();
		}
	}

	void ChangePhase(){
		if (phase == 0) {
			phase1.DisablePhase ();
		} else if (phase == 1) {
			phase2.DisablePhase ();
		}else if(phase ==2)
		{
			phase3.DisablePhase ();
		}
		phase++;
		Debug.Log ("Current phase " + phase);
		if (phase == 1) {
			phase2.EnablePhase ();
		}

		//Do phase3
		if (phase == 2) {
		
			phase3.EnablePhase ();
		}

	}
}
