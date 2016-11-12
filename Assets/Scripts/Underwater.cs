using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {

	bool fog = true;
	Color fogColor = new Color (0.22f,0.65f,0.77f,0.5f);
	float fogDensity = 0.002f;
	Material skybox;

	// Use this for initialization
	void Start () {
//

		//RenderSettings.skybox = skybox;
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
	}
}
