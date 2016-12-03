using UnityEngine;
using System.Collections;

public class BathySphereSpin : MonoBehaviour 
{

    public float spinSpeed = 1.0f;
    public float spinAngle = 3.0f;

    float initEulerAngle_y = 0.0f;

    bool triggerStop = false;

    void Awake()
    {
        EventManager.spinBathySphere += spinSetUp;
        EventManager.StopBathySpin += stopSpin;
    }


	// Use this for initialization
	void Start () 
    {
        initEulerAngle_y = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
       
        if (transform.eulerAngles.y < initEulerAngle_y - spinAngle || transform.eulerAngles.y > initEulerAngle_y + spinAngle) 
        {
            EventManager.CameraShaker (0.01f, 0.00009f);
            spinSpeed = -spinSpeed;
        }
         

        if ( triggerStop == true)
        {

            if (spinSpeed >= 10.0f)
            {
                spinSpeed -= 0.01f;
            }

            if(transform.eulerAngles.y < 180.5f && transform.eulerAngles.y > 179.5)
            {
                triggerStop = false;
                transform.eulerAngles = new Vector3(0, -180, 0);
                spinSpeed = 0.0f;
                spinAngle = 0.0f;
            }
        }


	}
        

    void spinSetUp(float i_spinSpeed, float i_spinAngle)
    {
        spinSpeed = i_spinSpeed;
        spinAngle = i_spinAngle;
    }


    void stopSpin()
    {
        triggerStop = true;
    }


}
