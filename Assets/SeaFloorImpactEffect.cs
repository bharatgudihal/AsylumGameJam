using UnityEngine;
using System.Collections;

public class SeaFloorImpactEffect : MonoBehaviour {

	ParticleSystem _emitter;

	void Awake () {
		_emitter = GetComponent<ParticleSystem> ();
	}

	public void Burst () {
		_emitter.Emit (20);
	}
}
