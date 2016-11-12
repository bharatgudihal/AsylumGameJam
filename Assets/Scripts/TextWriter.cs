using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextElement{

	private string text;
	private float delayTime;

	//the gets
	public string GetText(){return text;}
	public float GetDelay(){return delayTime;}


	public TextElement(string p_text, float p_delayTime){
		this.text = p_text;
		this.delayTime = p_delayTime;
	}

	public IEnumerator DisplayText(Text uiText)
	{


		int index = 0;
		while (index < this.GetText().Length) {
			uiText.text += this.GetText() [index];
			index++;
			yield return new WaitForSeconds (this.GetDelay());
		}

		yield return TextPause (uiText,2f);
	}

	private IEnumerator TextPause(Text uiText,float pauseTime)
	{
		yield return new WaitForSeconds (pauseTime);
		TextWipe (uiText);
	}


	private void TextWipe(Text uiText){
		uiText.text = "";
	}



}


public class TextWriter : MonoBehaviour {

	public Text uiText;

	public List<TextElement> textElements;

	void Awake(){
		EventManager.textWriter += SetTextElements;
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
}
