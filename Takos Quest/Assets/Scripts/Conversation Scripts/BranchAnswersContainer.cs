using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchAnswersContainer : MonoBehaviour {

	[Header("Answer Variables")]
	public BranchAnswerControl[] allAnswers;
	public int optionSelected;

	[Header("Text Box Manager Variables")]
	public BranchTextBoxManagerControl textBoxManager;

	[Header("Recapitulation Text Box Variables")]
	public GameObject recapButtonControl;
	public GameObject recapTextBox;

	[Header("Shuffle Position Variables")]
	public List<Vector3> allPosiblePositions;
	public List<Vector3> allPosiblePositionsTmp;
	// Use this for initialization
	void Start () {
		textBoxManager = GameObject.FindObjectOfType (typeof(BranchTextBoxManagerControl)) as BranchTextBoxManagerControl;
	}

	// Update is called once per frame
	void Update () {

	}
	public void SetAllOptionsTexts(string[] answersTexts){
		allAnswers [0].SetOptionText(answersTexts[0]);
		allAnswers [1].SetOptionText(answersTexts[1]);
		allAnswers [2].SetOptionText(answersTexts[2]);
	}
	public void DisappearOptions(){
		textBoxManager.SetNextDialogue (optionSelected);
		textBoxManager.EnableNextDialogueTextAfterAnswer ();
		gameObject.SetActive (false);
		recapTextBox.SetActive (false);
		recapButtonControl.SetActive (false);
	}

	public void ShuffleResponses(){
		for (int i = 0; i < allPosiblePositions.Count; i++) {
			allPosiblePositionsTmp.Add (allPosiblePositions [i]);
		}
		for (int i = 0; i < 3; i++) {
			int tmp = Random.Range (0, allPosiblePositionsTmp.Count);
			allAnswers [i].gameObject.transform.localPosition = allPosiblePositionsTmp [tmp];
			allPosiblePositionsTmp.RemoveAt (tmp);
		}
	}
}
