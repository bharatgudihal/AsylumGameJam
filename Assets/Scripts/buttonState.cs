using UnityEngine;
using System.Collections;

public class buttonState : MonoBehaviour 
{
	public GameObject gameManagerObject;
	CustomGameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		gameManager = gameManagerObject.GetComponent<CustomGameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
		

}
