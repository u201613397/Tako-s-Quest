using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ApplicateLanguageValue : MonoBehaviour {

	public TextAsset _textAsset;
	public string[] dialogueLines;
	private Text _text;
	// Use this for initialization
	void Awake () {
		_text = GetComponent<Text> ();
		if (_textAsset != null) {
			dialogueLines = _textAsset.text.Split ('\n');
		}
		ApplicateInitialChangeLanguage ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ApplicateChangeLanguage(int language){
		_text.text = dialogueLines [language];
	}
	public void ApplicateInitialChangeLanguage(){
		int tmp = PlayerPrefs.GetInt ("CurrentLanguage");
		ApplicateChangeLanguage (tmp);
	}
}

