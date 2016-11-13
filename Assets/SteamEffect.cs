// SteamEffect.cs

using UnityEngine;

/// <summary>
/// Class to handle the steam particle effect.
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
public class SteamEffect : MonoBehaviour {

	#region Vars

	/// <summary>
	/// The ParticleSystem attached to this object.
	/// </summary>
	ParticleSystem _steamEmitter;

	/// <summary>
	/// Initial velocity of steam particles.
	/// </summary>
	[Tooltip("Initial velocity of steam particles.")]
	[SerializeField]
	Vector3 _initialVelocity = new Vector3 (0f, 10f, 0f);

	/// <summary>
	/// The AudioSource attached to this object.
	/// </summary>
	AudioSource _source;

	/// <summary>
	/// Looping sound to play while emitting.
	/// </summary>
	[Tooltip("Looping sound to play while emitting.")]
	[SerializeField]
	AudioClip _loopSound;

	/// <summary>
	/// If true, a loop sound was provided.
	/// </summary>
	bool _useSound = false;

	#endregion
	#region Unity Callbacks

	void Awake () {
		// Init vars
		_source = GetComponent<AudioSource>();
		_steamEmitter = GetComponent<ParticleSystem>();

		// Scale emission rate to fit velocity
		var emissionModule = _steamEmitter.emission;
		emissionModule.rate = 10f * _initialVelocity.magnitude;

		// Set velocity
		var velocityOverTimeModule = _steamEmitter.velocityOverLifetime;
		velocityOverTimeModule.x = _initialVelocity.x;
		velocityOverTimeModule.y = _initialVelocity.y;
		velocityOverTimeModule.z = _initialVelocity.z;

		// Init sound
		if (_loopSound != default (AudioClip)) {
			_source.clip = _loopSound;
			_useSound = true;
		}
	}

	#endregion
	#region Methods

	/// <summary>
	/// Starts playing the emitter.
	/// </summary>
	public void Enable () {
		_steamEmitter.Play();
		if (_useSound) _source.Play();
	}

	/// <summary>
	/// Stops playing the emitter.
	/// </summary>
	public void Disable () {
		_steamEmitter.Stop();
		if (_useSound) _source.Stop();
	}

	#endregion
}
