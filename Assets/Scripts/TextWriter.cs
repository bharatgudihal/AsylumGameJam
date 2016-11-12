using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

class TextElement{

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
	private string test1 = "Tree is an awesome dude!";
	private string test2 = "The princess has exited the castle! You have to go find her";
	private string test3 = "The Vader is in the water for you !!!";
	private string test4 = "Maybe you should consider the razor";

	List<TextElement> textElements;

	void Awake(){
		textElements = new List<TextElement> ();

		TextElement element1 = new TextElement(test1,0.1f);
		TextElement element2 = new TextElement(test2,0.1f);
		TextElement element3 = new TextElement(test3,0.1f);
		TextElement element4 = new TextElement(test4,0.1f);

		textElements.Add (element1);
		textElements.Add (element2);
		textElements.Add (element3);
		textElements.Add (element4);
	}


	void Start(){
		StartCoroutine (ReadAllTextElements ());
		
	}

	IEnumerator ReadAllTextElements(){

		while (textElements.Count != 0) {
			yield return StartCoroutine(textElements [0].DisplayText(uiText));
			textElements.RemoveAt (0);
		}

	}
}
