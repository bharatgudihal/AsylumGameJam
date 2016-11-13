// SmallWaterLeakEffect.cs

using UnityEngine;

public class SmallWaterLeakEffect : MonoBehaviour {

	#region Vars

	/// <summary>
	/// Reference to the main water drop emitter.
	/// </summary>
	[Tooltip("Reference to the main water drop emitter.")]
	[SerializeField]
	ParticleSystem _mainDropEmitter;

	/// <summary>
	/// Reference to the small water drop emitter.
	/// </summary>
	[Tooltip("Reference to the small water drop emitter.")]
	[SerializeField]
	ParticleSystem _smallDropEmitter;

	/// <summary>
	/// Initial particle velocity.
	/// </summary>
	[Tooltip("Initial particle velocity.")]
	[SerializeField]
	Vector3 _initialVelocity = new Vector3 (5f, 0f, 0f);

	#endregion
	#region Unity Callbacks

	void Awake () {
		// Set velocity
		var mainVelocityOverLifetimeModule = _mainDropEmitter.velocityOverLifetime;
		mainVelocityOverLifetimeModule.x = _initialVelocity.x;
		mainVelocityOverLifetimeModule.y = _initialVelocity.y;
		mainVelocityOverLifetimeModule.z = _initialVelocity.z;

		var smallVelocityOverLifetimeModule = _smallDropEmitter.velocityOverLifetime;
		smallVelocityOverLifetimeModule.x = _initialVelocity.x * 0.75f;
		smallVelocityOverLifetimeModule.y = _initialVelocity.y * 0.5f;
		smallVelocityOverLifetimeModule.z = _initialVelocity.z * 0.75f;
	}

	#endregion
	#region Methods

	public void Enable () {
		_mainDropEmitter.Play();
		_smallDropEmitter.Play();
	}

	public void Disable () {
		_mainDropEmitter.Stop();
		_smallDropEmitter.Stop();
	}

	#endregion
}
