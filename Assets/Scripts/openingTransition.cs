using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	}


    public void transition()
    {
        StartCoroutine(setAlpha() );
    }


    IEnumerator setAlpha()
    {


        for(float i = 0; i <= 2.5f; i += Time.deltaTime)
        {
            image.color = new Color(0.0f, 0.0f, 0.0f, i * 0.4f);
            yield return 0;
        }

        SceneManager.LoadScene("MainScene");

    }
}
