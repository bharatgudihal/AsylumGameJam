using UnityEngine;
using System.Collections;

public class CustomGameManager : MonoBehaviour {
    int phase;
    Light ambient;
    float intensitySpeed = 0.05f;

	// Use this for initialization
	void Start () {
        phase = 0;
        ambient = GameObject.Find("ExteriorLight").GetComponent<Light>();        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ambient.intensity += intensitySpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ambient.intensity -= intensitySpeed;
        }
	}
}
