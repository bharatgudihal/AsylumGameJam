﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitRequest()
    {
        Application.Quit();
    }
}
