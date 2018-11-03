using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchActivateTextAtLineControl : MonoBehaviour {

	[Header("Dialogue Lines Variables")]
	public TextAsset[] arrayOfArchives;
	private TextAsset actualText;
	public int startLine;
	public int endLine;
	public bool isFirstDialogue;
	public bool isFinalDialogue;

	[Header("Text Box Manager Variables")]
	public BranchTextBoxManagerControl textBoxManagerTmp;

	[Header("Language Variables")]
	public int currentLanguage;

	[Header("Girls Variables")]
	public int portraitPoseToSend;
	public int portraitCharacterToSend;
	public int portraitEmotionToSend;

	[Header("Answers Variables")]
	public bool haveResponse;
	public int startAnswerText;
	public int[] positionsToSend;

	[Header("Aditiopns Functionalities Variables")]
	public bool destroyAfterActivate;
	public bool isAPlayerName;

	void Start () {
		ChangeLanguage ();
		if (isFirstDialogue) {
			Invoke ("SendReloadTextBoxManager", 1f);
		}
	}

	// Update is called once per frame
	void Update () {

	}
	public void SendReloadTextBoxManager(){

		textBoxManagerTmp.isAPlayerName = isAPlayerName;

		textBoxManagerTmp.ReloadScript (actualText, portraitEmotionToSend,portraitCharacterToSend,portraitPoseToSend);
		textBoxManagerTmp.currentLine = startLine;
		textBoxManagerTmp.endAtLine = endLine;
		textBoxManagerTmp.EnabledTextBox ();
		textBoxManagerTmp.SetPositions (positionsToSend);
		textBoxManagerTmp.haveResponse = haveResponse;

		if (haveResponse == true) {
			textBoxManagerTmp.SetAnswerText (startAnswerText);
		} else if (haveResponse == false && isFinalDialogue == false){
			textBoxManagerTmp.SetNextLinealDialogue (positionsToSend [0]);
		}
		if (destroyAfterActivate == true) { 
			Destroy (this.gameObject);
		}
	}
	public void ChangeLanguage(){
		currentLanguage = PlayerPrefs.GetInt("CurrentLanguage");
		actualText = arrayOfArchives [currentLanguage];
	}
}
