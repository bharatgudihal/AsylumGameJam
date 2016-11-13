// SparkSystem.cs

using UnityEngine;

/// <summary>
/// Class to handle the spark flash effect.
/// </summary>
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Light))]
public class SparkEffect : MonoBehaviour {

	#region Vars

	/// <summary>
	/// Smoke particle system reference.
	/// </summary>
	[SerializeField]
	[Tooltip("Smoke particle system reference.")]
	ParticleSystem _smokeEmitter;

	/// <summary>
	/// Spark particle system reference.
	/// </summary>
	[SerializeField]
	[Tooltip("Spark particle system reference.")]
	ParticleSystem _sparkEmitter;

	/// <summary>
	/// Number of smoke particles to emit per burst.
	/// </summary>
	[SerializeField]
	[Tooltip("Number of smoke particles to emit per burst.")]
	int _smokeCount = 6;

	/// <summary>
	/// Number of spark particles to emit per burst.
	/// </summary>
	[SerializeField]
	[Tooltip("Number of spark particles to emit per burst.")]
	int _sparkCount = 20;

	/// <summary>
	/// Initial velocity of particles.
	/// </summary>
	[Tooltip("Initial velocity of particles.")]
	[SerializeField]
	Vector3 _initialVelocity = new Vector3 (0f, 10f, 0f);

	/// <summary>
	/// Sound to play when bursting (optional).
	/// </summary>
	[SerializeField]
	[Tooltip("Sound to play when bursting (optional).")]
	AudioClip _burstSound;

	/// <summary>
	/// AudioSource attached to this GameObject.
	/// </summary>
	AudioSource _source;

	/// <summary>
	/// If true, sparks will collide with objects.
	/// </summary>
	[Tooltip("If true, sparks will collide with objects.")]
	[SerializeField]
	bool _sparkCollision = true;

	/// <summary>
	/// If true, will flash light on bursts.
	/// </summary>
	[Tooltip("If true, will flash light on bursts.")]
	[SerializeField]
	bool _useLight = true;

	/// <summary>
	/// Light attached to this GameObject.
	/// </summary>
	Light _light;

	/// <summary>
	/// Base intensity of the light.
	/// </summary>
	float _lightIntensity;

	#endregion
	#region Unity Callbacks

	void Awake () {
		// Init vars
		_source = GetComponent<AudioSource>();
		_light = GetComponent<Light>();
		_lightIntensity = _light.intensity;

		// Set velocity
		var velocityOverLifeModule = _sparkEmitter.velocityOverLifetime;
		velocityOverLifeModule.x = _initialVelocity.x;
		velocityOverLifeModule.y = _initialVelocity.y;
		velocityOverLifeModule.z = _initialVelocity.z;

		// Set collision
		var collisionModule = _sparkEmitter.collision;
		collisionModule.enabled = _sparkCollision;

		// Check for sound
		if (_burstSound != default(AudioClip))
			_source.clip = _burstSound;

		// Init light
		_light.enabled = _useLight;
		if (_light.enabled) _light.intensity = 0f;
	}

	void Update () {
		// Fade light
		if (_useLight && _light.intensity > 0f) {
			_light.intensity -= 0.1f;
		}
	}

	#endregion
	#region Methods

	/// <summary>
	/// Emits a burst of smoke and spark particles, and plays sound
	/// if available.
	/// </summary>
	public void Burst () {
		_smokeEmitter.Emit(_smokeCount);
		_sparkEmitter.Emit(_sparkCount);

		if (_burstSound != default(AudioClip))
			_source.Play();

		if (_useLight) _light.intensity = _lightIntensity;
	}

	#endregion
}
