using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phase4 : MonoBehaviour 
{

	public GameObject switch_Object_U;

	clickButton switch_U;

	List<TextElement> dialogue;
	public int step = 5;

	public float duration = 1.0F;
	public GameObject lightObject;
	Light light;

	// Use this for initialization
	void Start () 
	{
		light = lightObject.GetComponent<Light> (); 

		dialogue = new List<TextElement> ();
		dialogue.Add (new TextElement("", 0.1f, 2.0f));
		dialogue.Add (new TextElement("I have a solution", 0.1f, 4.0f));
		dialogue.Add (new TextElement("Flip the switches to your left", 0.1f, 4.0f));

		EventManager.CallTextWriter (dialogue);
		StartCoroutine (timeDelay(7));

		switch_U = switch_Object_U.gameObject.GetComponent<clickButton> ();
//		switch_D = switch_Object_D.gameObject.GetComponent<clickButton> ();
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if (step == 7) 
		{
			if (switch_U.isTrigger == true) 
			{
				StartCoroutine (callText ("Again", 0.1f, 8));
			}
		}
		if (step == 8) 
		{
			if (switch_U.isTrigger == true) 
			{
				StartCoroutine (Shinning (1.0f));
				StartCoroutine (callText ("Again!!!", 0.1f, 9));
			}
		}

		if (step == 9) 
		{
			if (switch_U.isTrigger == true) 
			{
				StartCoroutine (callText ("Good", 0.1f, 10));
				StartCoroutine (Shinning (10.0f));
			}
		}

	}
		
	IEnumerator Shinning(float time)
	{
		yield return new WaitForSecondsRealtime(0.1f);

		for (float i = 0; i <= time; i += Time.deltaTime) 
		{
			float phi = Time.time / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos(phi) * 0.5F + 1.0F;
			light.intensity = amplitude;

			yield return 0;
		}
	}
		
	IEnumerator callText(string text, float delay, int i_step)
	{
		yield return new WaitForSeconds(0.1f);
		EventManager.CalldisplayStrings (text, 0.1f, 1.0f);
		yield return new WaitForSeconds(1.0f);
		switch_U.isTrigger = false;
		step = i_step;
	}

	IEnumerator timeDelay(int i_step)
	{
		yield return new WaitForSeconds(13.0f);
		step = 7;
	}

}
