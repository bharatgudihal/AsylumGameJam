using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextElement{

	private string text;
	private float delayTime;
	private float timeVisible;


	//the gets
	public string GetText(){return text;}
	public float GetDelay(){return delayTime;}


	public TextElement(string p_text, float p_delayTime, float timeVisible){
		this.text = p_text;
		this.delayTime = p_delayTime;
		this.timeVisible = timeVisible;
	}

	public IEnumerator DisplayText(Text uiText)
	{
		int index = 0;
		while (index < this.GetText().Length) {
			uiText.text += this.GetText() [index];
			index++;
			yield return new WaitForSeconds (this.GetDelay());
		}

		yield return TextPause (uiText,timeVisible);
	}

	private IEnumerator TextPause(Text uiText,float pauseTime)
	{
		yield return new WaitForSeconds (pauseTime);
		TextWipe (uiText);
	}


	private void TextWipe(Text uiText){
		uiText.text = "";
	}


	public IEnumerator displayString(Text uiText)
	{

		int index = 0;
		while (index < this.GetText().Length) {
			uiText.text += this.GetText() [index];
			index++;
			yield return new WaitForSeconds (this.GetDelay());
		}

		yield return TextPause (uiText,timeVisible);
	}
}


public class TextWriter : MonoBehaviour {

	public Text uiText;

	public List<TextElement> textElements;

	bool displaying = false;

	void Awake(){
		EventManager.textWriter += SetTextElements;
		EventManager.displayStrings += displayString;
	}


	void Start(){		

	}
		
	IEnumerator ReadAllTextElements(){

		while (textElements.Count != 0) {
			yield return StartCoroutine(textElements [0].DisplayText(uiText));
			textElements.RemoveAt (0);
		}

	}

	private void SetTextElements(List<TextElement> elements){
		textElements = elements;
		StartCoroutine (ReadAllTextElements ());
	}
		

	private void displayString(string text, float delay, float timeVisible)
	{
		if (displaying == false) 
		{
			StartCoroutine (runString (text, delay, timeVisible));
			displaying = true;
		}
	}
		

	IEnumerator runString(string text, float delay, float timeVisible)
	{
		int index = 0;
		while (index < text.Length) 
		{
			uiText.text += text [index];
			index++;
			yield return new WaitForSeconds (delay);
		}
		displaying = false;
		yield return TextPause (timeVisible);
	}

	private IEnumerator TextPause(float pauseTime)
	{
		yield return new WaitForSeconds (pauseTime);
		uiText.text = "";
	}
}
