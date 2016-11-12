using UnityEngine;
using System.Collections;

public class CustomGameManager : MonoBehaviour {
    int phase;
	Phase1 phase1;

	void Awake(){
		EventManager.phaseChanger += ChangePhase;
	}

	// Use this for initialization
	void Start () {
        phase = 0;
		phase1 = this.gameObject.GetComponent<Phase1>();

    }
	
	// Update is called once per frame
	void Update () {
        if(phase == 0)
        {
            //Phase 1 shit
			phase1.Update();
        }
	}

	void ChangePhase(){
		phase++;
	}
}
