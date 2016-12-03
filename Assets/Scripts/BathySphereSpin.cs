using UnityEngine;
using System.Collections;

public class BathySphereSpin : MonoBehaviour 
{

    public float spinSpeed = 1.0f;
    public float spinAngle = 3.0f;

    float initEulerAngle_y = 0.0f;

    void Awake()
    {
        EventManager.spinBathySphere += spinSetUp;
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
            spinSpeed = -spinSpeed;
        }
	}


    void spinSetUp(float i_spinSpeed, float i_spinAngle)
    {
        spinSpeed = i_spinSpeed;
        spinAngle = i_spinAngle;
    }


    void stopSpin()
    {
        if (transform.eulerAngles.y < 180.5f || transform.eulerAngles.y > 179.5)
        {
            transform.eulerAngles.y = 180.0f;
        }
    }


}
