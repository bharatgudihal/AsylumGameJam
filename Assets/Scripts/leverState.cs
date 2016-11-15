using UnityEngine;
using System.Collections;

public class leverState : MonoBehaviour 
{
	lever leverclass;
	public bool leverEnabled;

	// Use this for initialization
	void Start () 
	{
		leverclass = this.gameObject.GetComponent<lever> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		display ();
	}

	virtual public void display()
	{
		
			//if (leverclass.isTrigger == true) {
				//AudioManager.instance.PlayOneShotSFX (AudioManager.instance.generalSFX [1]);
				//EventManager.CalldisplayStrings ("That should put you back on course", 0.1f, 0.5f);
				//leverclass.isTrigger = false;
			//}

	}
}
