using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchAnswerControl : MonoBehaviour {

	public Text optionTxt;
	public BranchAnswersContainer answerContainer;
	public int optionNumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void SetOptionText(string text){
		optionTxt.text = text;
	}
	public void OptionSelected(){
		answerContainer.optionSelected = optionNumber;
		answerContainer.DisappearOptions ();
	}
}
