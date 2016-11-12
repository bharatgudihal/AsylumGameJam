﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	public delegate void CameraShake (float intensity, float decay);
	public static event CameraShake shakeCamera;

	public delegate void WriteText (List<TextElement> dialogue);
	public static event WriteText textWriter;

	public delegate void ChangePhase ();
	public static event ChangePhase phaseChanger;

	public delegate void triggerMovement ();
	public static event triggerMovement RockMovement;


	public delegate void showStrings (string text, float delay, float timeVisible);
	public static event showStrings displayStrings;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void CameraShaker(float intensity, float decay){
		shakeCamera(intensity, decay);
	}

	public static void CallTextWriter(List<TextElement> dialogue){
		textWriter (dialogue);
	}

	public static void CallPhaseChanger(){
		phaseChanger ();
	}

	public static void CallRockMovement()
	{
		RockMovement ();
	}
		
	public static void CalldisplayStrings(string text, float delay, float timeVisible)
	{
		displayStrings (text, delay, timeVisible);
	}
}
