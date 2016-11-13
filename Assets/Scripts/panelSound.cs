using UnityEngine;
using System.Collections;

public class panelSound : MonoBehaviour 
{
	public AudioClip sound;
	private AudioSource source;

	bool playable = true;
	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.GetComponent<clickButton> ().isTrigger == true && playable == true) 
		{
			source.PlayOneShot (sound);
			playable = false;
		}
		if (this.gameObject.GetComponent<clickButton> ().isTrigger == false) 
		{
			playable = true;
		}
	}
}
