﻿using UnityEngine;
using System.Collections;

public class CustomGameManager : MonoBehaviour {
    int phase = 0;
	Phase1 phase1;
	Phase2 phase2;
	Phase3 phase3;
	Phase4 phase4;
	Phase5 phase5;

	void Awake(){
		
		EventManager.phaseChanger += ChangePhase;
	}

	// Use this for initialization
	void Start () {
		phase = 0;
		phase1 = this.gameObject.GetComponent<Phase1>();
		phase2 = this.gameObject.GetComponent<Phase2>();
		phase3 = this.gameObject.GetComponent<Phase3>();
		phase4 = this.gameObject.GetComponent<Phase4>();
		phase5 = this.gameObject.GetComponent<Phase5>();

    }
	
	// Update is called once per frame
	void Update () 
	{
		if (phase == 0) 
		{			
			phase1.Update ();
		} 
		else if (phase == 1) 
		{
			phase2.Update ();
		} 
		else if(phase == 2)
		{
			phase3.Update ();
		}
		else if(phase == 3)
		{
			phase4.Update ();
		}
		else if(phase == 4)
		{
			phase5.Update ();
		}
	}

	void ChangePhase()
	{
		if (phase == 0) 
		{
			phase1.DisablePhase ();
		} 
		else if (phase == 1) 
		{
			phase2.DisablePhase ();
		}
		else if(phase == 2)
		{
			phase3.DisablePhase ();
		}
		else if(phase == 3)
		{
			phase4.DisablePhase ();
		}


		phase++;


		if (phase == 1) 
		{
			phase2.EnablePhase ();
		}
	
		//Do phase3
		if (phase == 2) 
		{
			phase3.EnablePhase ();
		}

		if (phase == 3) 
		{
			phase4.EnablePhase ();
		}

		if (phase == 4) 
		{
			phase5.EnablePhase ();
		}




	}
}
