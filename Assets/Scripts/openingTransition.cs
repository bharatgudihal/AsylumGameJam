using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class openingTransition : MonoBehaviour 
{

    Image image;

	// Use this for initialization
	void Start () 
    {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        { 
            StartCoroutine(gotoMainScene());
        }
	}

    IEnumerator gotoMainScene()
    {
        yield return 0;
    }
}
