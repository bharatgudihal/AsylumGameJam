﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;
	public List<AudioSource> audioSources;
	private List<AudioSource> usedAudioSources;
	public AudioClip[] generalSFX;
	public AudioClip[] generalEnvironment;



	void Awake()
	{
		if (instance == null) {
			instance = this;

			usedAudioSources = new List<AudioSource> ();

		} else if (instance != this) {
			Destroy (gameObject);
		
		}
		DontDestroyOnLoad (gameObject);

	}

	void Start(){

		instance.PlayMusic (generalEnvironment[0],true);

	}

	//The music
	public void PlayMusic(AudioClip clip, bool loop){

		AudioSource current = audioSources[0];
		audioSources.RemoveAt(0);
		current.clip = clip;
		current.loop = loop;
		current.Play ();
		usedAudioSources.Add (current);
	}

	public void StopMusic(){
		foreach (AudioSource source in audioSources) {
			source.Stop ();
		}

		foreach (AudioSource source in usedAudioSources) {
			source.Stop ();
		}
	}

	void Update(){

		foreach (AudioSource source in usedAudioSources) {
			if (!source.isPlaying) {
				audioSources.Add (source);
			}
		}

	}



	//the sound effects
	public void PlayOneShotSFX(AudioClip clip){
		AudioSource current = audioSources[0];
		current.PlayOneShot (clip);
	}





}