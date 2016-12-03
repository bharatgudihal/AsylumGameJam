using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	Vector3 originPosition;
	Quaternion originRotation;


    public float p_shake_decay;
    public float p_shake_intensity;

    float shake_decay;
	float shake_intensity;

	void Awake()
    {
		EventManager.shakeCamera += Shake;
	}

	void Start()
    {
        
	}

	// Update is called once per frame
	void Update () {
	
        if (shake_intensity > 0)
        {
		
            //transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
        }
        else
        {
//            transform.localRotation = Quaternion.Euler(-174, 0, -180);
        }
	}


	//Shakes the camera
	void Shake(float intensity, float decay){
		//originPosition = transform.position;
        originRotation = transform.localRotation;
		shake_intensity = intensity;
		shake_decay = decay;
	}
}
