// BubblesEffect.cs

using UnityEngine;

/// <summary>
/// Class to handle the bubble effect.
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class BubblesEffect : MonoBehaviour {

	#region Vars

	/// <summary>
	/// Reference to the ParticleSystem attached to this object.
	/// </summary>
	ParticleSystem _bubbleEmitter;

	#endregion
	#region Unity Callbacks

	void Awake () {
		// Init vars
		_bubbleEmitter = GetComponent<ParticleSystem>();
	}

	#endregion
	#region Methods

	/// <summary>
	/// Enables the bubble emitter.
	/// </summary>
	public void Enable () {
		_bubbleEmitter.Play();
	}

	/// <summary>
	/// Disables the bubble emitter.
	/// </summary>
	public void Disable () {
		_bubbleEmitter.Stop();
	}

	/// <summary>
	/// No, not like burst the bubble. Emits the specified number of bubbles.
	/// </summary>
	public void Burst (int n) {
		_bubbleEmitter.Emit(n);
	}

	#endregion
}
